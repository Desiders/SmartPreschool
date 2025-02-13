using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static SmartPreschool.Database;

namespace SmartPreschool;

public partial class ReportsForm : Form
{
    private readonly AppDbContext db;
    private readonly ILogger<AttendanceForm> logger;

    public ReportsForm(IServiceProvider provider)
    {
        db = provider.GetRequiredService<AppDbContext>();
        logger = provider.GetRequiredService<ILogger<AttendanceForm>>();

        InitializeComponent();
    }

    private void ReportsForm_Load(object sender, EventArgs e)
    {
        dtpPeriodFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        dtpPeriodTo.Value = DateTime.Today;

        dtpPeriodFrom.ValueChanged += (s, e) => GenerateReport();
        dtpPeriodTo.ValueChanged += (s, e) => GenerateReport();

        GenerateReport();
    }

    private void GenerateReport()
    {
        var startDate = dtpPeriodFrom.Value.Date;
        var endDate = dtpPeriodTo.Value.Date;

        if (startDate > endDate)
        {
            MessageBox.Show("Дата начала не может быть позже даты окончания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var attendanceData = db.Children
           .Include(c => c.Group)
           .Select(c => new
           {
               ChildId = c.Id,
               c.FullName,
               GroupName = c.Group.Name,
               AttendedDays = db.Attendance.Count(a => a.ChildId == c.Id && a.Date >= startDate && a.Date <= endDate && a.Attended)
           })
           .ToList();

        dgvReport.Rows.Clear();

        int totalDays = endDate.Day - startDate.Day;

        foreach (var record in attendanceData)
        {
            int attendedDays = record.AttendedDays;
            double attendancePercentage = totalDays > 0 ? (attendedDays / (double)totalDays) * 100 : 0;
            int missedDays = totalDays - attendedDays;

            dgvReport.Rows.Add(record.FullName, record.GroupName, $"{attendancePercentage:F2}%", missedDays);
        }

        double avgAttendance = attendanceData.Any() ? attendanceData.Average(r => r.AttendedDays / (double)(totalDays == 0 ? 1 : totalDays)) * 100 : 0;
        int totalAttendance = attendanceData.Sum(r => r.AttendedDays);

        txtAverageAttendance.Text = $"{avgAttendance:F2}%";
        txtFullAttendance.Text = totalAttendance.ToString();
    }
}
