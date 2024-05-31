namespace Lab3
{
    partial class addNewForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ErrorLabel = new Label();
            NameLabel = new Label();
            NameTextBox = new TextBox();
            AddButton = new Button();
            SuspendLayout();
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(12, 9);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(201, 20);
            ErrorLabel.TabIndex = 0;
            ErrorLabel.Text = "Неверное имя директории.";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 64);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(126, 20);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Имя директории";
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NameTextBox.Location = new Point(156, 64);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(495, 27);
            NameTextBox.TabIndex = 2;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddButton.Location = new Point(156, 97);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(495, 29);
            AddButton.TabIndex = 3;
            AddButton.Text = "Создать";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // addNewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 168);
            Controls.Add(AddButton);
            Controls.Add(NameTextBox);
            Controls.Add(NameLabel);
            Controls.Add(ErrorLabel);
            Name = "addNewForm";
            Text = "Создать директорию";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ErrorLabel;
        private Label NameLabel;
        private TextBox NameTextBox;
        private Button AddButton;
    }
}