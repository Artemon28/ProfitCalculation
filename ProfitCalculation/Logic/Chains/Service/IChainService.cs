using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Handlings.Models;
using ProfitCalculation.Logic.Handlings.Repositories;
using ProfitCalculation.Logic.Handlings.Services;
using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.Logic.Materials.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.UI;

namespace ProfitCalculation.Logic.Chains.Service
{
    internal interface IChainService
    {
        List<Chain> MakeChains(List<Material> materials, List<Handling> handlings, ProgressImportForm progressBarForm);
    }
}
