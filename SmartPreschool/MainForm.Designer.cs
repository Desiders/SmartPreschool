namespace SmartPreschool
{
    partial class MainForm
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
            menuMain = new MenuStrip();
            menuRegisterChild = new ToolStripMenuItem();
            menuAttendance = new ToolStripMenuItem();
            menuReports = new ToolStripMenuItem();
            panelContainer = new Panel();
            label1 = new Label();
            lblWelcomeAttendance = new Label();
            lblWelcomeRegister = new Label();
            lblWelcome = new Label();
            menuMain.SuspendLayout();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { menuRegisterChild, menuAttendance, menuReports });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(684, 27);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // menuRegisterChild
            // 
            menuRegisterChild.Font = new Font("Segoe UI", 10F);
            menuRegisterChild.Name = "menuRegisterChild";
            menuRegisterChild.Size = new Size(139, 23);
            menuRegisterChild.Text = "Регистрация детей";
            menuRegisterChild.Click += menuRegisterChild_Click;
            // 
            // menuAttendance
            // 
            menuAttendance.Font = new Font("Segoe UI", 10F);
            menuAttendance.Name = "menuAttendance";
            menuAttendance.Size = new Size(167, 23);
            menuAttendance.Text = "Журнал посещаемости";
            menuAttendance.Click += menuAttendance_Click;
            // 
            // menuReports
            // 
            menuReports.Font = new Font("Segoe UI", 10F);
            menuReports.Name = "menuReports";
            menuReports.Size = new Size(69, 23);
            menuReports.Text = "Отчёты";
            menuReports.Click += menuReports_Click;
            // 
            // panelContainer
            // 
            panelContainer.Controls.Add(label1);
            panelContainer.Controls.Add(lblWelcomeAttendance);
            panelContainer.Controls.Add(lblWelcomeRegister);
            panelContainer.Controls.Add(lblWelcome);
            panelContainer.Location = new Point(0, 30);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(700, 500);
            panelContainer.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 116);
            label1.Name = "label1";
            label1.Size = new Size(489, 18);
            label1.TabIndex = 3;
            label1.Text = "Для работы с отчётами о посещаемости нажмите кнопку \"Отчёты\"";
            // 
            // lblWelcomeAttendance
            // 
            lblWelcomeAttendance.AutoSize = true;
            lblWelcomeAttendance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeAttendance.Location = new Point(12, 88);
            lblWelcomeAttendance.Name = "lblWelcomeAttendance";
            lblWelcomeAttendance.Size = new Size(589, 18);
            lblWelcomeAttendance.TabIndex = 2;
            lblWelcomeAttendance.Text = "Для работы с журналом посещаемости нажмите кнопку \"Журнал посещаемости\"";
            // 
            // lblWelcomeRegister
            // 
            lblWelcomeRegister.AutoSize = true;
            lblWelcomeRegister.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeRegister.Location = new Point(12, 60);
            lblWelcomeRegister.Name = "lblWelcomeRegister";
            lblWelcomeRegister.Size = new Size(444, 18);
            lblWelcomeRegister.TabIndex = 1;
            lblWelcomeRegister.Text = "Для регистрации детей нажмите кнопку \"Регистрация детей\"";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(12, 23);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(497, 22);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Добро пожаловать в систему детей детского сада!";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 511);
            Controls.Add(panelContainer);
            Controls.Add(menuMain);
            MainMenuStrip = menuMain;
            Name = "MainForm";
            Text = "Главная";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem menuRegisterChild;
        private ToolStripMenuItem menuAttendance;
        private ToolStripMenuItem menuReports;
        private Panel panelContainer;
        private Label lblWelcome;
        private Label lblWelcomeRegister;
        private Label lblWelcomeAttendance;
        private Label label1;
    }
}
