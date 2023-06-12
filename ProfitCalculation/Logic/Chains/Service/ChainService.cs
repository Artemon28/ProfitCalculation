using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Handlings.Models;
using ProfitCalculation.Logic.Handlings.Repositories;
using ProfitCalculation.Logic.Handlings.Services;
using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.Logic.Materials.Repositories;
using ProfitCalculation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProfitCalculation.Logic.Handlings.Models.Handling;

namespace ProfitCalculation.Logic.Chains.Service
{
    internal class ChainService : IChainService
    {
        private IHandlingService _handlingService;

        public ChainService(IMaterialRepository materialRepository, IHandlingRepository handlingRepository, IHandlingService handlingService)
        {
            _handlingService = handlingService;
        }

        public List<Chain> MakeChains(List<Material> materials, List<Handling> handlings, ProgressImportForm progressBarForm)
        {
            List<Chain> allChains = new List<Chain>();
            List<Handling> sortedHandlings = handlings.OrderBy(m => m.CreatedForId).ToList();

            int qty = 0;
            foreach (Material material in materials)
            {
                if (material.Amount != null)
                {
                    allChains.AddRange(makeChain(sortedHandlings, material.Id, material.Id, 0, 1.0m,
                        (decimal)material.Amount, (decimal)material.Price) ?? Enumerable.Empty<Chain>());
                }
                qty++;
                progressBarForm.UpdateProgress(qty * 100 / materials.Count());
                Application.DoEvents();
            }
            return allChains;
        }

        private List<Chain>? makeChain(List<Handling> sortedHandlings,
            long materialId, long baseMaterialId, int step, decimal? throughFlowRatio, decimal amount, decimal price)
        {
            List<Chain> result = new List<Chain>();
            if (step == 0)
            {
                Chain zeroChain = new Chain();
                zeroChain.ReleaseId = materialId;
                zeroChain.ExpenseRatio = 1;
                zeroChain.BaseMaterialId = baseMaterialId;
                zeroChain.Step = 0;
                zeroChain.ThroughFlowRatio = 1;
                zeroChain.Amount = amount;
                zeroChain.Distribute = 0;
                zeroChain.Remain = amount;
                zeroChain.Price = price;
                result.Add(zeroChain);
            }
            int firstIndex = sortedHandlings.FindIndex(h => h.CreatedForId == materialId);
            if (firstIndex < 0)
            {
                if (step == 0)
                {
                    Console.WriteLine($"no products from {materialId}");
                }
                return result;
            }
            for (int i = firstIndex; i < sortedHandlings.Count() && sortedHandlings[i].CreatedForId == materialId; i++)
            {
                if (sortedHandlings[i].ExpenseRatio == 0 || sortedHandlings[i].ExpenseRatio == null)
                {
                    continue;
                }
                Chain chain = new Chain();
                chain.CreatedForId = sortedHandlings[i].CreatedForId;
                chain.ReleaseId = sortedHandlings[i].ReleaseId;
                chain.ConversionId = sortedHandlings[i].ConversionId;
                chain.ExpenseRatio = sortedHandlings[i].ExpenseRatio;
                chain.BaseMaterialId = baseMaterialId;
                chain.Step = step + 1;

                chain.Wastes = _handlingService.GetWastes(chain.ReleaseId);
                chain.addExpenses = _handlingService.CalculateExpenses(chain.ReleaseId, chain.ConversionId ?? 0);

                chain.ThroughFlowRatio = throughFlowRatio * sortedHandlings[i].ExpenseRatio;
                chain.Amount = (decimal)(amount / sortedHandlings[i].ExpenseRatio);
                chain.Distribute = 0.0m;
                chain.Remain = chain.Amount;
                chain.Price = (decimal)(price * sortedHandlings[i].ExpenseRatio);
                chain.CostPrice = chain.Price - chain.Wastes + chain.addExpenses;
                chain.EndCostPrice = chain.CostPrice * chain.Amount;

                result.Add(chain);
                result.AddRange(makeChain(sortedHandlings, chain.ReleaseId, baseMaterialId, step + 1,
                    chain.ThroughFlowRatio, chain.Amount, chain.Price));
            }
            return result;
        }
    }
}
