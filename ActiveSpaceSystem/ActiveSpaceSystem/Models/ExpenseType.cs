public class ExpenseType
{
    public int Id { get; set; }
    public string ExpenseName { get; set; }

    // دالة تعيد قائمة ثابتة بالأنواع التي ظهرت في واجهتك
    public static List<ExpenseType> GetDefaultTypes()
    {
        return new List<ExpenseType>
        {
            new ExpenseType { Id = 1, ExpenseName = "كهرباء" },
            new ExpenseType { Id = 2, ExpenseName = "صيانة الملاعب" },
            new ExpenseType { Id = 3, ExpenseName = "رواتب الموظفين" },
        };
    }
}