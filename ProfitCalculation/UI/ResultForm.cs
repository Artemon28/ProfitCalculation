using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.OrderRealizer.Models;
using ProfitCalculation.Presenter;
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
    public partial class ResultForm : Form
    {
        internal ResultForm(List<Chain> _resChains, List<Portfol> _portfols, decimal _profit)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ResultPresenter presenter = new ResultPresenter(this);
            btnSave.Click += SaveResults;
            btnBack.Click += ReturnCalcView;
            resChains = _resChains;
            portfols = _portfols;
            profit = _profit;
            label1.Text += profit.ToString();
        }
        private List<Chain> resChains;
        private List<Portfol> portfols;
        private decimal profit;

        private static ResultForm instance;

        internal List<Chain> GetChains()
        {
            return resChains;
        }

        internal List<Portfol> GetPortfol()
        {
            return portfols;
        }

        public event EventHandler SaveResults;
        public event EventHandler ReturnCalcView;
    }
}
