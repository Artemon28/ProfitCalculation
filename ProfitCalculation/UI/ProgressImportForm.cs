using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfitCalculation.UI
{
    public partial class ProgressImportForm : Form
    {
        public ProgressImportForm()
        {
            InitializeComponent();
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            label1.Visible = true;
            progressBar1.Value = 0;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void UpdateProgress(int percentage)
        {
            progressBar1.Value = percentage;
        }

        public void RenameBar(string name)
        {
            label1.Text = name;
        }

        public void StopProgressReport()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }
            Close();
        }
    }
}
