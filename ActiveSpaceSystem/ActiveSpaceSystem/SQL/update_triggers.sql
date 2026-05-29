-- ============================================
-- تحديث تريجر المخزون وإنشاء تريجر المنتجات الجديد
-- لضمان بقائهما متوافقين بعد عملية الـ Normalization
-- ============================================

-- 1. أولاً: إنشاء التريجر الجديد لجدول PRODUCTS
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_GenerateProductRef' AND parent_id = OBJECT_ID('PRODUCTS'))
BEGIN
    DROP TRIGGER trg_GenerateProductRef;
END
GO

CREATE TRIGGER [dbo].[trg_GenerateProductRef]
ON [dbo].[PRODUCTS]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @InsertedRows TABLE (
        RowID INT IDENTITY(1,1), 
        product_ref VARCHAR(20),
        product_name NVARCHAR(100), 
        category_ref VARCHAR(20), 
        selling_price DECIMAL(18,2),
        rental_rate DECIMAL(18,2),
        usage_type INT, 
        min_quantity INT
    );
    
    INSERT INTO @InsertedRows (product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity) 
    SELECT product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity FROM inserted;

    DECLARE @CurrentRow INT = 1, @TotalRows INT = (SELECT COUNT(*) FROM @InsertedRows), @NextAvailableSeq INT;
    
    WHILE @CurrentRow <= @TotalRows
    BEGIN
        IF EXISTS (SELECT 1 FROM @InsertedRows WHERE RowID = @CurrentRow AND (product_ref IS NULL OR product_ref = ''))
        BEGIN
            -- البحث عن الرقم التسلسلي الفارغ التالي (Gap-filling) في جدول PRODUCTS
            SELECT @NextAvailableSeq = MIN(t1.Seq) FROM (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Seq FROM master.sys.all_objects) t1 
            LEFT JOIN [PRODUCTS] p ON CAST(RIGHT(p.product_ref, 4) AS INT) = t1.Seq AND p.product_ref LIKE 'INV-%' 
            WHERE p.product_ref IS NULL;
            
            UPDATE @InsertedRows SET product_ref = 'INV-' + RIGHT('0000' + CAST(@NextAvailableSeq AS VARCHAR(4)), 4) WHERE RowID = @CurrentRow;
        END
        SET @CurrentRow = @CurrentRow + 1;
    END
    
    INSERT INTO [PRODUCTS] (product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity) 
    SELECT product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity FROM @InsertedRows;
END;
GO

PRINT 'تم إنشاء التريجر trg_GenerateProductRef بنجاح لجدول PRODUCTS';
GO


-- 2. ثانياً: تحديث التريجر الحالي لجدول INVENTORY ليتطابق مع الأعمدة الجديدة فقط
-- ملاحظة: قمنا بإزالة الأعمدة المحذوفة (item_name, category_ref, usage_type, rental_rate, min_quantity)
-- لكي لا يتعطل التريجر عند حذف الأعمدة.
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_GenerateItemRef' AND parent_id = OBJECT_ID('INVENTORY'))
BEGIN
    DROP TRIGGER trg_GenerateItemRef;
END
GO

CREATE TRIGGER [dbo].[trg_GenerateItemRef]
ON [dbo].[INVENTORY]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @InsertedRows TABLE (
        RowID INT IDENTITY(1,1), 
        item_ref VARCHAR(50), 
        current_quantity INT, 
        damaged_quantity INT,
        product_ref VARCHAR(20)
    );
    
    -- نقوم بإدراج الحقول المتوافقة مع الهيكل الجديد فقط
    INSERT INTO @InsertedRows (item_ref, current_quantity, damaged_quantity, product_ref) 
    SELECT item_ref, current_quantity, damaged_quantity, product_ref FROM inserted;

    DECLARE @CurrentRow INT = 1, @TotalRows INT = (SELECT COUNT(*) FROM @InsertedRows), @NextAvailableSeq INT;
    
    WHILE @CurrentRow <= @TotalRows
    BEGIN
        IF EXISTS (SELECT 1 FROM @InsertedRows WHERE RowID = @CurrentRow AND (item_ref IS NULL OR item_ref = ''))
        BEGIN
            -- توليد تسلسل جديد للمخزون إذا لم يمرر الكود ref
            SELECT @NextAvailableSeq = MIN(t1.Seq) FROM (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Seq FROM master.sys.all_objects) t1 
            LEFT JOIN [INVENTORY] i ON CAST(RIGHT(i.item_ref, 4) AS INT) = t1.Seq AND i.item_ref LIKE 'INV-%' 
            WHERE i.item_ref IS NULL;
            
            UPDATE @InsertedRows SET item_ref = 'INV-' + RIGHT('0000' + CAST(@NextAvailableSeq AS VARCHAR(4)), 4) WHERE RowID = @CurrentRow;
        END
        SET @CurrentRow = @CurrentRow + 1;
    END
    
    INSERT INTO [INVENTORY] (item_ref, current_quantity, damaged_quantity, product_ref) 
    SELECT item_ref, current_quantity, damaged_quantity, product_ref FROM @InsertedRows;
END;
GO

PRINT 'تم تحديث التريجر trg_GenerateItemRef بنجاح لجدول INVENTORY';
GO

-- 3. ثالثاً: تحديث تريجر المشتريات ليتطابق مع الأعمدة المحذوفة
-- تم إزالة (inventory_category_ref, selling_price)
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_GeneratePurchaseRef' AND parent_id = OBJECT_ID('PURCHASES'))
BEGIN
    DROP TRIGGER trg_GeneratePurchaseRef;
END
GO

CREATE TRIGGER [dbo].[trg_GeneratePurchaseRef]
ON [dbo].[PURCHASES]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @InsertedRows TABLE (RowID INT IDENTITY(1,1), 
        expense_ref VARCHAR(50), purchase_date DATE, item_ref VARCHAR(50),
        quantity INT, unit_price DECIMAL(10,2), supplier_name NVARCHAR(200), employee_id VARCHAR(15), 
        notes NVARCHAR(500), purchase_ref VARCHAR(50));
        
    INSERT INTO @InsertedRows (expense_ref, purchase_date, item_ref, quantity, unit_price, supplier_name, employee_id, notes, purchase_ref)
    SELECT expense_ref, purchase_date, item_ref, quantity, unit_price, supplier_name, employee_id, notes, purchase_ref FROM inserted;

    DECLARE @CurrentRow INT = 1, @TotalRows INT = (SELECT COUNT(*) FROM @InsertedRows), @NextAvailableSeq INT, @TodayContext VARCHAR(8);
    WHILE @CurrentRow <= @TotalRows
    BEGIN
        IF EXISTS (SELECT 1 FROM @InsertedRows WHERE RowID = @CurrentRow AND (purchase_ref IS NULL OR purchase_ref = ''))
        BEGIN
            SET @TodayContext = CONVERT(VARCHAR(8), (SELECT purchase_date FROM @InsertedRows WHERE RowID = @CurrentRow), 112);
            SELECT @NextAvailableSeq = MIN(t1.Seq) FROM (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Seq FROM master.sys.all_objects) t1 
            LEFT JOIN [PURCHASES] pc ON CAST(RIGHT(pc.purchase_ref, 3) AS INT) = t1.Seq AND pc.purchase_ref LIKE 'PUR-' + @TodayContext + '-%' 
            WHERE pc.purchase_ref IS NULL;
            UPDATE @InsertedRows SET purchase_ref = 'PUR-' + @TodayContext + '-' + RIGHT('000' + CAST(@NextAvailableSeq AS VARCHAR(3)), 3) WHERE RowID = @CurrentRow;
        END
        SET @CurrentRow = @CurrentRow + 1;
    END
    INSERT INTO [PURCHASES] (purchase_ref, expense_ref, purchase_date, item_ref, quantity, unit_price, supplier_name, employee_id, notes)
    SELECT purchase_ref, expense_ref, purchase_date, item_ref, quantity, unit_price, supplier_name, employee_id, notes FROM @InsertedRows;
END;
GO

PRINT 'تم تحديث التريجر trg_GeneratePurchaseRef بنجاح لجدول PURCHASES';
GO
