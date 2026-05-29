-- ============================================
-- هجرة بيانات المنتجات: إنشاء جدول PRODUCTS
-- يجب تشغيل هذا السكربت مرة واحدة فقط
-- ============================================

-- أولاً: حذف جدول PRODUCTS إذا كان موجود من محاولة سابقة فاشلة
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PRODUCTS')
BEGIN
    DROP TABLE PRODUCTS;
    PRINT 'تم حذف جدول PRODUCTS القديم (من محاولة سابقة)';
END
GO

-- الخطوة 1: معرفة نوع category_ref الفعلي من INVENTORY_CATEGORIES
-- ثم إنشاء PRODUCTS بنفس النوع بدون FOREIGN KEY لتجنب مشاكل التوافق
CREATE TABLE PRODUCTS (
    product_ref VARCHAR(20) PRIMARY KEY,
    product_name NVARCHAR(100) NOT NULL,
    category_ref VARCHAR(20) NULL,
    selling_price DECIMAL(18,2) DEFAULT 0,
    rental_rate DECIMAL(18,2) DEFAULT 0,
    usage_type INT DEFAULT 1,  -- 1=بيع, 2=إيجار, 3=كلاهما
    min_quantity INT DEFAULT 5
);
PRINT 'تم إنشاء جدول PRODUCTS بنجاح';
GO

-- الخطوة 2: نقل البيانات من INVENTORY إلى PRODUCTS
INSERT INTO PRODUCTS (product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity)
SELECT 
    i.item_ref,
    i.item_name,
    i.category_ref,
    ISNULL((SELECT TOP 1 p.selling_price FROM PURCHASES p WHERE p.item_ref = i.item_ref ORDER BY p.purchase_date DESC), 0),
    ISNULL(i.rental_rate, 0),
    ISNULL(i.usage_type, 1),
    ISNULL(i.min_quantity, 5)
FROM INVENTORY i
WHERE NOT EXISTS (SELECT 1 FROM PRODUCTS pr WHERE pr.product_ref = i.item_ref);
GO

PRINT 'تم نقل البيانات إلى جدول PRODUCTS بنجاح';
GO

-- الخطوة 3: إضافة عمود product_ref في INVENTORY إذا لم يكن موجوداً
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INVENTORY' AND COLUMN_NAME = 'product_ref')
BEGIN
    ALTER TABLE INVENTORY ADD product_ref VARCHAR(20) NULL;
    PRINT 'تم إضافة عمود product_ref إلى جدول INVENTORY';
END
GO

-- تحديث product_ref في INVENTORY ليشير إلى PRODUCTS
UPDATE INVENTORY SET product_ref = item_ref WHERE product_ref IS NULL;
GO

-- الخطوة 4: حذف القيود (Constraints) المرتبطة بالأعمدة القديمة ثم حذف الأعمدة
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INVENTORY' AND COLUMN_NAME = 'item_name')
BEGIN
    -- حذف قيد الفريد (Unique Constraint) على اسم الصنف إن وجد
    IF EXISTS (SELECT * FROM sys.objects WHERE name = 'UQ_INVENTORY_ItemName' AND type = 'UQ')
    BEGIN
        ALTER TABLE INVENTORY DROP CONSTRAINT UQ_INVENTORY_ItemName;
    END

    -- حذف القيد الأجنبي (Foreign Key) على category_ref إن وجد
    DECLARE @fk_name NVARCHAR(100);
    SELECT @fk_name = name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('INVENTORY') AND referenced_object_id = OBJECT_ID('INVENTORY_CATEGORIES');
    IF @fk_name IS NOT NULL
    BEGIN
        DECLARE @drop_fk_sql NVARCHAR(MAX) = 'ALTER TABLE INVENTORY DROP CONSTRAINT ' + @fk_name;
        EXEC sp_executesql @drop_fk_sql;
    END

    -- حذف القيود الافتراضية (Default Constraints) على الأعمدة القديمة إن وجدت
    DECLARE @drop_defaults_sql NVARCHAR(MAX) = '';
    SELECT @drop_defaults_sql = @drop_defaults_sql + 'ALTER TABLE INVENTORY DROP CONSTRAINT [' + name + ']; '
    FROM sys.default_constraints
    WHERE parent_object_id = OBJECT_ID('INVENTORY') 
      AND parent_column_id IN (
          SELECT column_id FROM sys.columns 
          WHERE object_id = OBJECT_ID('INVENTORY') 
            AND name IN ('usage_type', 'rental_rate', 'min_quantity', 'item_name', 'category_ref')
      );
    IF @drop_defaults_sql <> '' EXEC sp_executesql @drop_defaults_sql;

    -- حذف الفهارس (Indexes) المرتبطة بالأعمدة القديمة إن وجدت
    DECLARE @drop_indexes_sql NVARCHAR(MAX) = '';
    SELECT @drop_indexes_sql = @drop_indexes_sql + 'DROP INDEX [' + i.name + '] ON INVENTORY; '
    FROM sys.indexes i
    JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    WHERE i.object_id = OBJECT_ID('INVENTORY') 
      AND i.is_primary_key = 0 
      AND i.is_unique_constraint = 0
      AND c.name IN ('usage_type', 'rental_rate', 'min_quantity', 'item_name', 'category_ref');
    IF @drop_indexes_sql <> '' EXEC sp_executesql @drop_indexes_sql;

    -- الآن يمكن حذف الأعمدة بأمان
    ALTER TABLE INVENTORY DROP COLUMN item_name, category_ref, usage_type, rental_rate, min_quantity;
    PRINT 'تم حذف الأعمدة القديمة بنجاح من جدول INVENTORY';
END
GO

-- الخطوة 5: حذف الأعمدة القديمة من جدول PURCHASES لتنظيف قاعدة البيانات
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PURCHASES' AND COLUMN_NAME = 'inventory_category_ref')
BEGIN
    -- 1. حذف القيد الأجنبي (Foreign Key) على inventory_category_ref إن وجد
    DECLARE @fk_name NVARCHAR(100);
    SELECT @fk_name = name FROM sys.foreign_keys 
    WHERE parent_object_id = OBJECT_ID('PURCHASES') 
      AND referenced_object_id = OBJECT_ID('INVENTORY_CATEGORIES');
    IF @fk_name IS NOT NULL
    BEGIN
        DECLARE @drop_fk_sql NVARCHAR(MAX) = 'ALTER TABLE PURCHASES DROP CONSTRAINT [' + @fk_name + ']';
        EXEC sp_executesql @drop_fk_sql;
    END

    -- 2. حذف القيود الافتراضية (Default Constraints) على الأعمدة القديمة إن وجدت
    DECLARE @drop_defaults_sql NVARCHAR(MAX) = '';
    SELECT @drop_defaults_sql = @drop_defaults_sql + 'ALTER TABLE PURCHASES DROP CONSTRAINT [' + name + ']; '
    FROM sys.default_constraints
    WHERE parent_object_id = OBJECT_ID('PURCHASES') 
      AND parent_column_id IN (
          SELECT column_id FROM sys.columns 
          WHERE object_id = OBJECT_ID('PURCHASES') 
            AND name IN ('inventory_category_ref', 'selling_price')
      );
    IF @drop_defaults_sql <> '' EXEC sp_executesql @drop_defaults_sql;

    -- 3. حذف الأعمدة بأمان
    ALTER TABLE PURCHASES DROP COLUMN inventory_category_ref, selling_price;
    PRINT 'تم حذف الأعمدة القديمة بنجاح من جدول PURCHASES';
END
GO

-- عرض النتائج للتأكد
SELECT * FROM PRODUCTS;
GO

PRINT '=== تمت الهجرة بنجاح ===';
GO
