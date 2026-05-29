public static class DataGridExtensions
{
    public static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
        var dgvType = dgv.GetType();
        var pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        pi.SetValue(dgv, setting, null);
    }
}