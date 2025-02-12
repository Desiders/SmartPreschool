using Microsoft.Extensions.DependencyInjection;

namespace SmartPreschool
{
    public partial class MainForm : Form
    {
        private IServiceProvider provider;

        public MainForm(IServiceProvider provider)
        {
            this.provider = provider;

            InitializeComponent();
        }

        private void LoadForm(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }

        private void menuRegisterChild_Click(object sender, EventArgs e)
        {
            LoadForm(new RegisterForm(this.provider));
        }

        private void menuAttendance_Click(object sender, EventArgs e)
        {
            LoadForm(new AttendanceForm(this.provider));
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportsForm(this.provider));
        }
    }
}
