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
            menuMain.SuspendLayout();
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
            panelContainer.Location = new Point(0, 30);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(700, 500);
            panelContainer.TabIndex = 1;
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
            Text = "Form1";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem menuRegisterChild;
        private ToolStripMenuItem menuAttendance;
        private ToolStripMenuItem menuReports;
        private Panel panelContainer;
    }
}
