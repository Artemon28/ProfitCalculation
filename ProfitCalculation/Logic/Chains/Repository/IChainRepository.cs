using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;

namespace ProfitCalculation.Logic.Chains.Repository
{
    internal interface IChainRepository
    {
        void SaveChains<T>(List<Chain> chains) where T : PlainChain, new();
    }
}
