using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;

namespace ProfitCalculation.Logic.Chains.Repository
{
    internal class ChainRepository : IChainRepository
    {
        private readonly ProfitCalculatingContext _dbContext;

        public ChainRepository(ProfitCalculatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChains<T>(List<Chain> chains) where T : PlainChain, new()
        {
            _dbContext.AddRange(ChainMapper.ToChainEntityList<T>(chains));
            _dbContext.SaveChanges();
        }
    }
}
