namespace SmartPreschool
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblChildName = new Label();
            txtChildName = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblParentName = new Label();
            txtParentName = new TextBox();
            lblPhone = new Label();
            mtbPhone = new MaskedTextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblGroup = new Label();
            cbxGroup = new ComboBox();
            SuspendLayout();
            // 
            // lblChildName
            // 
            lblChildName.AutoSize = true;
            lblChildName.Font = new Font("Segoe UI", 10F);
            lblChildName.Location = new Point(18, 28);
            lblChildName.Name = "lblChildName";
            lblChildName.Size = new Size(99, 19);
            lblChildName.TabIndex = 0;
            lblChildName.Text = "ФИО ребёнка:";
            // 
            // txtChildName
            // 
            txtChildName.Location = new Point(183, 25);
            txtChildName.Name = "txtChildName";
            txtChildName.Size = new Size(214, 25);
            txtChildName.TabIndex = 1;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 10F);
            lblBirthDate.Location = new Point(18, 70);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(110, 19);
            lblBirthDate.TabIndex = 2;
            lblBirthDate.Text = "Дата рождения:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(183, 64);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(214, 25);
            dtpBirthDate.TabIndex = 3;
            // 
            // lblParentName
            // 
            lblParentName.AutoSize = true;
            lblParentName.Font = new Font("Segoe UI", 10F);
            lblParentName.Location = new Point(14, 104);
            lblParentName.Name = "lblParentName";
            lblParentName.Size = new Size(163, 19);
            lblParentName.TabIndex = 4;
            lblParentName.Text = "ФИО родителя/опекуна:";
            // 
            // txtParentName
            // 
            txtParentName.Location = new Point(183, 101);
            txtParentName.Name = "txtParentName";
            txtParentName.Size = new Size(214, 25);
            txtParentName.TabIndex = 5;
            txtParentName.Validating += TBox_Validating;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.Location = new Point(18, 140);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(66, 19);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Телефон:";
            // 
            // mtbPhone
            // 
            mtbPhone.Location = new Point(183, 137);
            mtbPhone.Mask = "+7 (999) 999-99-99";
            mtbPhone.Name = "mtbPhone";
            mtbPhone.Size = new Size(214, 25);
            mtbPhone.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.Location = new Point(18, 179);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(133, 19);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Адрес проживания:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(183, 176);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(214, 25);
            txtAddress.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10F);
            btnSave.Location = new Point(18, 276);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 31);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(132, 276);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.Font = new Font("Segoe UI", 10F);
            lblGroup.Location = new Point(18, 218);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(57, 19);
            lblGroup.TabIndex = 12;
            lblGroup.Text = "Группа:";
            // 
            // cbxGroup
            // 
            cbxGroup.FormattingEnabled = true;
            cbxGroup.Location = new Point(183, 215);
            cbxGroup.Name = "cbxGroup";
            cbxGroup.Size = new Size(214, 25);
            cbxGroup.Sorted = true;
            cbxGroup.TabIndex = 13;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 522);
            Controls.Add(cbxGroup);
            Controls.Add(lblGroup);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(mtbPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtParentName);
            Controls.Add(lblParentName);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblBirthDate);
            Controls.Add(txtChildName);
            Controls.Add(lblChildName);
            Font = new Font("Segoe UI", 10F);
            Name = "RegisterForm";
            Text = "Регистрация детей";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChildName;
        private TextBox txtChildName;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;
        private Label lblParentName;
        private TextBox txtParentName;
        private Label lblPhone;
        private MaskedTextBox mtbPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;
        private Label lblGroup;
        private ComboBox cbxGroup;
    }
}