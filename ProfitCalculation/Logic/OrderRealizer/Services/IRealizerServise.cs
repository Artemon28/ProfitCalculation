using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.Logic.OrderRealizer.Models;
using ProfitCalculation.Logic.Orders.Models;
using ProfitCalculation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.OrderRealizer.Services
{
    internal interface IRealizerServise
    {
        (List<Portfol>, decimal) RealizeOrdersByLowestCost(List<Order> orders, List<Chain> chains, DateTime startDate, DateTime endDate, ProgressImportForm progressBarForm, List<Material> materials);
        decimal CalculateProfit(List<Portfol> portfol);
        List<Portfol> RealizeOrdersByLeastHandlings(List<Order> orders, List<Chain> chains, DateTime startDate, DateTime endDate, ProgressImportForm progressBarForm, List<Material> materials);
        public void SaveChainsExcel(List<Chain> chains, string fileName);
    }
}
