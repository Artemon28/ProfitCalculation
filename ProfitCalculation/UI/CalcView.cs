using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.OrderRealizer.Models;
using ProfitCalculation.Presenter;
using ProfitCalculation.UI.Interfaces;

namespace ProfitCalculation.UI
{
    public partial class CalcView : Form
    {
        public CalcView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CalculatePresenter presenter = new CalculatePresenter(this);
            btnCalculate.Click += CalculateProfit;
        }

        private static CalcView instance;

        public event EventHandler CalculateProfit;

        public static CalcView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CalcView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        public Boolean Get_radioButton1()
        {
            return radioButton1.Checked;
        }
        public Boolean Get_radioButton2()
        {
            return radioButton2.Checked;
        }

        public DateTime GetDateTime1()
        {
            return dateTimePicker1.Value;
        }
        public DateTime GetDateTime2()
        {
            return dateTimePicker2.Value;
        }
        public void SetWarning(String message)
        {
            labelWarning.ForeColor = Color.Red;
            labelWarning.Text = message;
            labelWarning.Visible = true;
        }

        public void DeleteWarning()
        {
           labelWarning.Visible = false;
        }

        internal void OpenResults(List<Chain> _resChains, List<Portfol> _portfols, decimal _profit)
        {
            Hide();

            ResultForm resultForm = new ResultForm(_resChains, _portfols, _profit);
            resultForm.MdiParent = this.MdiParent;
            resultForm.FormBorderStyle = FormBorderStyle.None;
            resultForm.Dock = DockStyle.Fill;
            resultForm.Show();


            resultForm.Show();
            Dispose();
        }
    }
}
