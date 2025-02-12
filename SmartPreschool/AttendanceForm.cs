using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using static SmartPreschool.Database;
using static SmartPreschool.Models;

namespace SmartPreschool;

public partial class AttendanceForm : Form
{
    private readonly AppDbContext db;
    private readonly ILogger<AttendanceForm> logger;

    public AttendanceForm(IServiceProvider provider)
    {
        db = provider.GetRequiredService<AppDbContext>();
        logger = provider.GetRequiredService<ILogger<AttendanceForm>>();

        InitializeComponent();

        dtpAttendanceDate.Value = DateTime.Today;
    }

    private async Task LoadGroups()
    {
        var groups = await db.Groups.ToListAsync();

        cbxCheckGroup.Items.Clear();
        cbxCheckGroup.DataSource = groups;
        cbxCheckGroup.DisplayMember = nameof(Group.Name);
        cbxCheckGroup.ValueMember = nameof(Group.Id);
        cbxCheckGroup.SelectedIndex = -1;
    }

    private async Task LoadAttendance()
    {
        var selectedDate = dtpAttendanceDate.Value.Date;

        List<Child> children;
        if (cbxCheckGroup.SelectedValue is not int groupId)
        {
            children = await db.Children.ToListAsync();
        }
        else
        {
            children = await db.Children
                .Where(c => c.GroupId == groupId)
                .ToListAsync();
        }

        var attendanceRecords = await db.Attendance
            .Where(a => a.Date == selectedDate)
            .ToDictionaryAsync(a => a.ChildId);

        dgvAttendance.Rows.Clear();

        foreach (var child in children)
        {
            var attended = attendanceRecords.TryGetValue(child.Id, out var attendance) && attendance.Attended;
            var reason = attendance?.Reason ?? string.Empty;

            dgvAttendance.Rows.Add(child.Id, child.FullName, attended, reason);
        }
    }

    private async void AttendanceForm_Load(object sender, EventArgs e)
    {
        await LoadGroups();
        await LoadAttendance();
    }

    private async void cbxCheckGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        await LoadAttendance();
    }

    private async void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
    {
        await LoadAttendance();
    }

    private async void btnSaveAttendance_Click(object sender, EventArgs e)
    {
        var selectedDate = dtpAttendanceDate.Value.Date;

        foreach (DataGridViewRow row in dgvAttendance.Rows)
        {
            if (row.Cells[0].Value is not int childId) continue;
            if (row.Cells[2].Value is not bool attended) continue;

            string? reason = attended ? null : row.Cells[3].Value?.ToString();

            var attendanceRecord = await db.Attendance
                .FirstOrDefaultAsync(a => a.ChildId == childId && a.Date == selectedDate);

            if (attendanceRecord == null)
            {
                db.Attendance.Add(new()
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

        await db.SaveChangesAsync();
        MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
