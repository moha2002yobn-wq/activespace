using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Forms;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.MainForms;
using ActiveSpaceSystem.Forms.SideForms;
using ActiveSpaceSystem.Forms.DialogForms;
namespace ActiveSpaceSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            //Application.Run(new Dashboard());
        }
    }
}