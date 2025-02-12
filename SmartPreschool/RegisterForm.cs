using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static SmartPreschool.Database;
using static SmartPreschool.Models;

namespace SmartPreschool;

public partial class RegisterForm : Form
{
    //private readonly CancellationTokenSource cts;
    private readonly AppDbContext db;
    private readonly ILogger<RegisterForm> logger;

    public RegisterForm(IServiceProvider provider)
    {
        this.db = provider.GetRequiredService<AppDbContext>();
        this.logger = provider.GetRequiredService<ILogger<RegisterForm>>();

        InitializeComponent();
    }

    private async Task LoadGroups()
    {
        var groups = await db.Groups.ToListAsync();

        cbxGroup.Items.Clear();
        cbxGroup.DataSource = groups;
        cbxGroup.DisplayMember = nameof(Group.Name);
        cbxGroup.ValueMember = nameof(Group.Id);
    }

    private async void RegisterForm_Load(object sender, EventArgs e) => await LoadGroups();

    private async void btnSave_Click(object sender, EventArgs e)
    {
        List<string> missingFields = [];

        if (string.IsNullOrWhiteSpace(txtChildName.Text))
            missingFields.Add(lblChildName.Text);
        if (string.IsNullOrWhiteSpace(txtParentName.Text))
            missingFields.Add(lblParentName.Text);
        if (string.IsNullOrWhiteSpace(mtbPhone.Text))
            missingFields.Add(lblPhone.Text);
        if (string.IsNullOrWhiteSpace(txtAddress.Text))
            missingFields.Add(lblAddress.Text);
        if (cbxGroup.SelectedValue is null)
            missingFields.Add(lblGroup.Text);

        if (missingFields.Count > 0)
        {
            string warningMessage = "Заполните следующие поля:\n- " + string.Join("\n- ", missingFields);
            MessageBox.Show(warningMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            db.Children.Add(new()
            {
                FullName = txtChildName.Text,
                BirthDate = dtpBirthDate.Value,
                ParentFullName = txtParentName.Text,
                ParentPhone = mtbPhone.Text,
                ResidentialAddress = txtAddress.Text,
                GroupId = Convert.ToInt32(cbxGroup.SelectedValue),
            });
            await db.SaveChangesAsync();

            MessageBox.Show("Ребёнок зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            logger.LogError("Ошибка при регистрации ребёнка {message}", ex.Message);
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        txtChildName.Text = txtParentName.Text = mtbPhone.Text = txtAddress.Text = cbxGroup.Text = string.Empty;
    }

    private void TBox_Validating(object sender, CancelEventArgs e)
    {
        // Пример, можно юзать на нескольких, но возможно много мороки с этим.
        if (sender is TextBoxBase t && string.IsNullOrEmpty(t.Text)) e.Cancel = true;
    }
}
