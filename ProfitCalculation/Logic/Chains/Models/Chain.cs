using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Chains.Models
{
    internal class Chain
    {
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

        public override string ToString()
        {
            return $"ConversionId: {ConversionId}, ReleaseId: {ReleaseId}, CreatedForId: {CreatedForId}, BaseMaterialId: {BaseMaterialId}, Step: {Step}, ExpenseRatio: {ExpenseRatio}, ThroughFlowRatio: {ThroughFlowRatio}, Amount: {Amount}, Price: {Price}, Wastes: {Wastes}, addExpenses: {addExpenses}, CostPrice: {CostPrice}, EndCostPrice: {EndCostPrice}";
        }
    }
}
