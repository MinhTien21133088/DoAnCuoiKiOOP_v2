using DoAnCuoiKiOOP_v2;
namespace WinFormsApp
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InputUnicode();
            OutputUnicode();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FDangNhap());
        }

        public static void InputUnicode()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }

        public static void OutputUnicode()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }
    }

    
}