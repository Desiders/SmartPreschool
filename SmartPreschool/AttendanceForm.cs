using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using static SmartPreschool.Database;
using static SmartPreschool.Models;
using System.Data.Entity;
using System.Windows.Forms;

namespace SmartPreschool
{
    public partial class AttendanceForm : Form
    {
        private AppDbContext db;
        private ILogger logger;

        public AttendanceForm(IServiceProvider provider)
        {
            this.db = provider.GetRequiredService<AppDbContext>();
            this.logger = provider.GetRequiredService<ILogger>();

            InitializeComponent();

            dtpAttendanceDate.Value = DateTime.Today;

            LoadGroups();
            LoadAttendance();
        }

        private void LoadGroups()
        {
            var groups = db.Groups.ToList();

            cbxCheckGroup.Items.Clear();
            cbxCheckGroup.DataSource = groups;
            cbxCheckGroup.DisplayMember = "Name";
            cbxCheckGroup.ValueMember = "Id";
            cbxCheckGroup.SelectedIndex = -1;
        }

        private void LoadAttendance()
        {
            var selectedDate = dtpAttendanceDate.Value.Date;

            List<Child> children;
            if (cbxCheckGroup.SelectedValue is int groupId) {
                children = db.Children
                    .Where(c => c.GroupId == groupId)
                    .ToList();
            } else {
                children = db.Children
                    .ToList();
            }

            var attendanceRecords = db.Attendance
                .Where(a => a.Date == selectedDate)
                .ToDictionary(a => a.ChildId);

            dgvAttendance.Rows.Clear();

            foreach (var child in children)
            {
                var attended = attendanceRecords.TryGetValue(child.Id, out var attendance) && attendance.Attended;
                var reason = attendance?.Reason ?? "";

                dgvAttendance.Rows.Add(child.Id, child.FullName, attended, reason);
            }
        }

        private void cbxCheckGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            var selectedDate = dtpAttendanceDate.Value.Date;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.Cells[0].Value is not int childId) continue;

                object? value = row.Cells[2].Value;
                if (value == null) continue;
                bool attended = (bool)value;

                string? reason = attended ? null : row.Cells[3].Value?.ToString();

                var attendanceRecord = db.Attendance
                    .FirstOrDefault(a => a.ChildId == childId && a.Date == selectedDate);

                if (attendanceRecord == null)
                {
                    db.Attendance.Add(new Attendance
                    {
                        ChildId = childId,
                        Date = selectedDate,
                        Attended = attended,
                        Reason = reason
                    });
                }
                else
                {
                    attendanceRecord.Attended = attended;
                    attendanceRecord.Reason = reason;
                }
            }

            db.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
