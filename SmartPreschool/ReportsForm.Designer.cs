namespace SmartPreschool
{
    partial class ReportsForm
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
            lblPeriodFrom = new Label();
            dtpPeriodFrom = new DateTimePicker();
            lblPeriodTo = new Label();
            dtpPeriodTo = new DateTimePicker();
            dgvReport = new DataGridView();
            colChildName = new DataGridViewTextBoxColumn();
            colGroup = new DataGridViewTextBoxColumn();
            colAttendanceRate = new DataGridViewTextBoxColumn();
            colMissedDays = new DataGridViewTextBoxColumn();
            lblAverageAttendance = new Label();
            txtAverageAttendance = new TextBox();
            lblFullAttendance = new Label();
            txtFullAttendance = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblPeriodFrom
            // 
            lblPeriodFrom.AutoSize = true;
            lblPeriodFrom.Font = new Font("Segoe UI", 10F);
            lblPeriodFrom.Location = new Point(34, 19);
            lblPeriodFrom.Name = "lblPeriodFrom";
            lblPeriodFrom.Size = new Size(71, 19);
            lblPeriodFrom.TabIndex = 0;
            lblPeriodFrom.Text = "Период с:";
            // 
            // dtpPeriodFrom
            // 
            dtpPeriodFrom.Font = new Font("Segoe UI", 10F);
            dtpPeriodFrom.Location = new Point(124, 13);
            dtpPeriodFrom.Name = "dtpPeriodFrom";
            dtpPeriodFrom.Size = new Size(200, 25);
            dtpPeriodFrom.TabIndex = 1;
            // 
            // lblPeriodTo
            // 
            lblPeriodTo.AutoSize = true;
            lblPeriodTo.Font = new Font("Segoe UI", 10F);
            lblPeriodTo.Location = new Point(34, 49);
            lblPeriodTo.Name = "lblPeriodTo";
            lblPeriodTo.Size = new Size(81, 19);
            lblPeriodTo.TabIndex = 2;
            lblPeriodTo.Text = "Период по:";
            // 
            // dtpPeriodTo
            // 
            dtpPeriodTo.CalendarFont = new Font("Segoe UI", 10F);
            dtpPeriodTo.Location = new Point(124, 49);
            dtpPeriodTo.Name = "dtpPeriodTo";
            dtpPeriodTo.Size = new Size(200, 23);
            dtpPeriodTo.TabIndex = 3;
            // 
            // dgvReport
            // 
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Columns.AddRange(new DataGridViewColumn[] { colChildName, colGroup, colAttendanceRate, colMissedDays });
            dgvReport.Location = new Point(34, 90);
            dgvReport.Name = "dgvReport";
            dgvReport.Size = new Size(500, 300);
            dgvReport.TabIndex = 5;
            // 
            // colChildName
            // 
            colChildName.HeaderText = "ФИО ребёнка";
            colChildName.Name = "colChildName";
            colChildName.ReadOnly = true;
            // 
            // colGroup
            // 
            colGroup.HeaderText = "Группа";
            colGroup.Name = "colGroup";
            colGroup.ReadOnly = true;
            // 
            // colAttendanceRate
            // 
            colAttendanceRate.HeaderText = "Посещаемость (%)";
            colAttendanceRate.Name = "colAttendanceRate";
            // 
            // colMissedDays
            // 
            colMissedDays.HeaderText = "Количество пропусков";
            colMissedDays.Name = "colMissedDays";
            // 
            // lblAverageAttendance
            // 
            lblAverageAttendance.AutoSize = true;
            lblAverageAttendance.Font = new Font("Segoe UI", 10F);
            lblAverageAttendance.Location = new Point(345, 19);
            lblAverageAttendance.Name = "lblAverageAttendance";
            lblAverageAttendance.Size = new Size(162, 19);
            lblAverageAttendance.TabIndex = 6;
            lblAverageAttendance.Text = "Средняя посещаемость:";
            // 
            // txtAverageAttendance
            // 
            txtAverageAttendance.Font = new Font("Segoe UI", 10F);
            txtAverageAttendance.Location = new Point(513, 16);
            txtAverageAttendance.Name = "txtAverageAttendance";
            txtAverageAttendance.ReadOnly = true;
            txtAverageAttendance.Size = new Size(100, 25);
            txtAverageAttendance.TabIndex = 7;
            // 
            // lblFullAttendance
            // 
            lblFullAttendance.AutoSize = true;
            lblFullAttendance.Font = new Font("Segoe UI", 10F);
            lblFullAttendance.Location = new Point(345, 49);
            lblFullAttendance.Name = "lblFullAttendance";
            lblFullAttendance.Size = new Size(122, 19);
            lblFullAttendance.TabIndex = 10;
            lblFullAttendance.Text = "Всего посещений:";
            // 
            // txtFullAttendance
            // 
            txtFullAttendance.Font = new Font("Segoe UI", 10F);
            txtFullAttendance.Location = new Point(513, 50);
            txtFullAttendance.Name = "txtFullAttendance";
            txtFullAttendance.ReadOnly = true;
            txtFullAttendance.Size = new Size(100, 25);
            txtFullAttendance.TabIndex = 11;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(txtFullAttendance);
            Controls.Add(lblFullAttendance);
            Controls.Add(txtAverageAttendance);
            Controls.Add(lblAverageAttendance);
            Controls.Add(dgvReport);
            Controls.Add(dtpPeriodTo);
            Controls.Add(lblPeriodTo);
            Controls.Add(dtpPeriodFrom);
            Controls.Add(lblPeriodFrom);
            Name = "ReportsForm";
            Text = "Сводка посещаемости детей";
            Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPeriodFrom;
        private DateTimePicker dtpPeriodFrom;
        private Label lblPeriodTo;
        private DateTimePicker dtpPeriodTo;
        private DataGridView dgvReport;
        private Label lblAverageAttendance;
        private TextBox txtAverageAttendance;
        private DataGridViewTextBoxColumn colChildName;
        private DataGridViewTextBoxColumn colGroup;
        private DataGridViewTextBoxColumn colAttendanceRate;
        private DataGridViewTextBoxColumn colMissedDays;
        private Label lblFullAttendance;
        private TextBox txtFullAttendance;
    }
}