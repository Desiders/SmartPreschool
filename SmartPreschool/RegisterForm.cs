using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static SmartPreschool.Database;
using static SmartPreschool.Models;

namespace SmartPreschool
{
    public partial class RegisterForm : Form
    {
        private AppDbContext db;
        private ILogger logger;

        public RegisterForm(IServiceProvider provider)
        {
            this.db = provider.GetRequiredService<AppDbContext>();
            this.logger = provider.GetRequiredService<ILogger>();

            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groups = db.Groups.ToList();

            cbxGroup.Items.Clear();
            cbxGroup.DataSource = groups;
            cbxGroup.DisplayMember = "Name";
            cbxGroup.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var missingFields = new List<string>();

                if (string.IsNullOrWhiteSpace(txtChildName.Text))
                    missingFields.Add("ФИО ребёнка");
                if (string.IsNullOrWhiteSpace(txtParentName.Text))
                    missingFields.Add("ФИО родителя");
                if (string.IsNullOrWhiteSpace(mtbPhone.Text))
                    missingFields.Add("Телефон родителя");
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    missingFields.Add("Адрес проживания");
                if (cbxGroup.SelectedValue == null)
                    missingFields.Add("Группа");

                if (missingFields.Count > 0)
                {
                    string warningMessage = "Заполните следующие поля:\n- " + string.Join("\n- ", missingFields);
                    MessageBox.Show(warningMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Children.Add(new Child
                {
                    FullName = txtChildName.Text,
                    BirthDate = dtpBirthDate.Value,
                    ParentFullName = txtParentName.Text,
                    ParentPhone = mtbPhone.Text,
                    ResidentialAddress = txtAddress.Text,
                    GroupId = Convert.ToInt32(cbxGroup.SelectedValue),
                });
                db.SaveChanges();

                MessageBox.Show("Ребёнок зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError($"Ошибка при регистрации ребёнка {ex.Message}");
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtChildName.Text = "";
            txtParentName.Text = "";
            mtbPhone.Text = "";
            txtAddress.Text = "";
            cbxGroup.Text = "";
        }
    }
}
