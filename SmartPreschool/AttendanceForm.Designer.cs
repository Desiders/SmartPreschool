namespace SmartPreschool
{
    partial class AttendanceForm
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
            lblSelectDate = new Label();
            dtpAttendanceDate = new DateTimePicker();
            dgvAttendance = new DataGridView();
            btnSaveAttendance = new Button();
            colChildName = new DataGridViewTextBoxColumn();
            colGroup = new DataGridViewTextBoxColumn();
            colPresent = new DataGridViewCheckBoxColumn();
            colReason = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // lblSelectDate
            // 
            lblSelectDate.AutoSize = true;
            lblSelectDate.Font = new Font("Segoe UI", 10F);
            lblSelectDate.Location = new Point(28, 31);
            lblSelectDate.Name = "lblSelectDate";
            lblSelectDate.Size = new Size(106, 19);
            lblSelectDate.TabIndex = 0;
            lblSelectDate.Text = "Выберите дату:";
            // 
            // dtpAttendanceDate
            // 
            dtpAttendanceDate.Font = new Font("Segoe UI", 10F);
            dtpAttendanceDate.Location = new Point(151, 25);
            dtpAttendanceDate.Name = "dtpAttendanceDate";
            dtpAttendanceDate.Size = new Size(200, 25);
            dtpAttendanceDate.TabIndex = 1;
            // 
            // dgvAttendance
            // 
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { colChildName, colGroup, colPresent, colReason });
            dgvAttendance.Location = new Point(30, 66);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.Size = new Size(500, 300);
            dgvAttendance.TabIndex = 2;
            // 
            // btnSaveAttendance
            // 
            btnSaveAttendance.Font = new Font("Segoe UI", 10F);
            btnSaveAttendance.Location = new Point(30, 386);
            btnSaveAttendance.Name = "btnSaveAttendance";
            btnSaveAttendance.Size = new Size(157, 28);
            btnSaveAttendance.TabIndex = 3;
            btnSaveAttendance.Text = "Сохранить изменения";
            btnSaveAttendance.UseVisualStyleBackColor = true;
            // 
            // colChildName
            // 
            colChildName.HeaderText = "ФИО ребёнка";
            colChildName.Name = "colChildName";
            // 
            // colGroup
            // 
            colGroup.HeaderText = "Группа";
            colGroup.Name = "colGroup";
            // 
            // colPresent
            // 
            colPresent.HeaderText = "Присутствует";
            colPresent.Name = "colPresent";
            // 
            // colReason
            // 
            colReason.HeaderText = "Причина отсутствия";
            colReason.Items.AddRange(new object[] { "Болезнь", "Отпуск/каникулы", "Семейные обстоятельства", "Медицинский осмотр/вакцинация", "Погодные условия", "Опоздание", "Карантин", "Другое" });
            colReason.Name = "colReason";
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(btnSaveAttendance);
            Controls.Add(dgvAttendance);
            Controls.Add(dtpAttendanceDate);
            Controls.Add(lblSelectDate);
            Name = "AttendanceForm";
            Text = "AttendanceForm";
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectDate;
        private DateTimePicker dtpAttendanceDate;
        private DataGridView dgvAttendance;
        private Button btnSaveAttendance;
        private DataGridViewTextBoxColumn colChildName;
        private DataGridViewTextBoxColumn colGroup;
        private DataGridViewCheckBoxColumn colPresent;
        private DataGridViewComboBoxColumn colReason;
    }
}