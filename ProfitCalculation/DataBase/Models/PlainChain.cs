using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.DataBase.Models
{
    public partial class PlainChain
    {
        public int Id { get; set; }
        public int? ConversionId { get; set; }
        public long ReleaseId { get; set; }
        public long? CreatedForId { get; set; }
        public long? BaseMaterialId { get; set; }
        public int Step { get; set; }
        public decimal? ExpenseRatio { get; set; }
        public decimal? ThroughFlowRatio { get; set; }
        public decimal Amount { get; set; }
        public decimal Distribute { get; set; }
        public decimal Remain { get; set; }
        public decimal Price { get; set; }
        public decimal Wastes { get; set; }
        public decimal addExpenses { get; set; }
        public decimal CostPrice { get; set; }
        public decimal EndCostPrice { get; set; }
    }
}
