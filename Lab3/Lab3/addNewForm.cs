namespace Lab3
{
    public partial class addNewForm : Form
    {
        public addNewForm()
        {
            InitializeComponent();

            controllerInterface = ManageClass.GetControllerInterface();
        }

        public static class ExceptionStrings
        {
            public const string Matching_names = "Директория с таким именем уже сущесвует";
            public const string SymbolReserv = "Невозможно использовать файл с зарезервированным символом в названии.";
            public const string Lenght = "Невозможно создать директорию с длиной имени больше 20 символов.";
            public const string Null_name = "Невозможно создать директорию без имени";
            public const string NoConnection = "Невозможно архивировать.";
        }

        public static bool checkName(string name)
        {
            string nameDir = "ExistingDirectory";
            List<string> failSymbol = new List<string>() { "/", @"\", "|", "*", ":", "?", @"""", "<", ">" };

            if (name == nameDir)
            {
                throw new Exception(ExceptionStrings.Matching_names);
            }

            if (failSymbol.Any(name.Contains))
            {
                throw new Exception(ExceptionStrings.SymbolReserv);
            }

            int maxLenghtNameDir = 20;

            if (name.Length >= maxLenghtNameDir)
            {
                throw new Exception(ExceptionStrings.Lenght);
            }

            if (name.Length == null || name.Length == 0)
            {
                throw new Exception(ExceptionStrings.Null_name);
            }

            return true;
        }

        public ToConnectControllerInterface controllerInterface = null;
        public SaveDirInterface clickToArchive(string name)
        {
            if (checkName(name))
            {
                if (controllerInterface.tryConnect())
                {
                    SaveDirInterface saveDir = controllerInterface.getNameDir();

                    controllerInterface.save(name);

                    return saveDir;
                }
                else
                {
                    throw new Exception(ExceptionStrings.NoConnection);
                }

            }
            return null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";

            try
            {
                string name = NameTextBox.Text;

                SaveDirInterface saveDir = clickToArchive(name);

                ErrorLabel.Text = "Создана директория " + saveDir.Name;
                if (MessageBox.Show("Создана директория " + saveDir.Name, "Внимание!") == DialogResult.OK)
                {
                    this.Close();
                }
            }

            catch (Exception exception)
            {
                ErrorLabel.Text = exception.Message;
            }
        }
    }
}