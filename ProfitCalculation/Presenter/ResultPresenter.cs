using Microsoft.Extensions.DependencyInjection;
using ProfitCalculation.Logic.OrderRealizer.Services;
using ProfitCalculation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Presenter
{
    internal class ResultPresenter
    {
        private ResultForm resForm;

        public ResultPresenter(ResultForm resForm)
        {
            this.resForm = resForm;
            this.resForm.SaveResults += SaveResults;
            this.resForm.ReturnCalcView += ReturnCalcView;
        }
        private void SaveResults(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                var serviceProvider = MainPresenter.services.BuildServiceProvider();
                var realizer = serviceProvider.GetService<IRealizerServise>();

                realizer.SaveChainsExcel(resForm.GetChains(), fileName);
            }
        }

        private void ReturnCalcView(object sender, EventArgs e)
        {
            resForm.Hide();
            CalcView calcView = new CalcView();
            calcView.MdiParent = resForm.MdiParent;
            calcView.FormBorderStyle = FormBorderStyle.None;
            calcView.Dock = DockStyle.Fill;
            calcView.Show();
            resForm.Dispose();
        }
    }
}
