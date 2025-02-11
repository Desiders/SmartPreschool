namespace SmartPreschool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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
            LoadForm(new RegisterForm());
        }

        private void menuAttendance_Click(object sender, EventArgs e)
        {
            LoadForm(new AttendanceForm());
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportsForm());
        }
    }
}
