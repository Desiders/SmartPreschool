using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace SmartPreschool;

public partial class ReportsForm : Form
{
    private IServiceProvider provider;

    public ReportsForm(IServiceProvider provider)
    {
        this.provider = provider;

        InitializeComponent();
    }
}
