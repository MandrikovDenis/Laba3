namespace Lab3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

#if DEBUG
            if (args.Length > 0)
            {
                ManageClass.index = Convert.ToInt32(args[0]);
            }
#endif
            Application.Run(new addNewForm());
        }
    }
}