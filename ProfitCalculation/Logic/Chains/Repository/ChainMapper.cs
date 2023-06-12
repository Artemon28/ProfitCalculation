using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Chains.Repository
{
    internal class ChainMapper
    {
        public static List<T> ToChainEntityList<T>(List<Chain> chains) where T : PlainChain, new()
        {

            var resultChain = new List<T>();
            foreach (var chain in chains)
            {
                resultChain.Add(ToChainEntity<T>(chain));
            }
            return resultChain;
        }

        public static T ToChainEntity<T>(Chain chain) where T : PlainChain, new()
        {
            var resultChain = new T();
            resultChain.ConversionId = chain.ConversionId;
            resultChain.ReleaseId = chain.ReleaseId;
            resultChain.CreatedForId = chain.CreatedForId;
            resultChain.BaseMaterialId = chain.BaseMaterialId;
            resultChain.Step = chain.Step;
            resultChain.ExpenseRatio = chain.ExpenseRatio;
            resultChain.ThroughFlowRatio = chain.ThroughFlowRatio;
            resultChain.Amount = chain.Amount;
            resultChain.Distribute = chain.Distribute;
            resultChain.Remain = chain.Remain;
            resultChain.Price = chain.Price;
            resultChain.Wastes = chain.Wastes;
            resultChain.addExpenses = chain.addExpenses;
            resultChain.CostPrice = chain.CostPrice;
            resultChain.EndCostPrice = chain.EndCostPrice;

            return resultChain;
        }

    }
}
