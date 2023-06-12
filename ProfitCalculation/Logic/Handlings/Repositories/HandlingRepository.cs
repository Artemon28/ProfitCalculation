using Microsoft.EntityFrameworkCore;
using ProfitCalculation.Logic.Handlings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;

namespace ProfitCalculation.Logic.Handlings.Repositories
{
    internal class HandlingRepository : IHandlingRepository
    {
        private readonly ProfitCalculatingContext _dbContext;

        public HandlingRepository(ProfitCalculatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Handling> GetAllHandlings()
        {
            var materialEntities = _dbContext.GuideCalculationMaterials.ToList();
            var orders = HandlingMapperUtility.Map(materialEntities);
            return orders;
        }

        public Dictionary<long, Expenses> GetAllExpenses()
        {
            var expensesEntity = _dbContext.BasicPricings.ToList();
            var expenses = HandlingMapperUtility.Map(expensesEntity);
            return expenses;
        } 

        public Expenses? GetExpensesById(long id)
        {
            //if (_dbContext.BasicPricings.Any(bp => bp.CipherId == id))
            //{
                var expensesEntity = _dbContext.BasicPricings.SingleOrDefault(e => e.CipherId == id);
                if (expensesEntity == null)
                {
                    return null;
                }
                var expenses = HandlingMapperUtility.Map(expensesEntity);
                return expenses;
            //}
            //return null;
        }

        public ConversionExpenses GetconversionExpensesById(long id)
        {
            var expensesEntity = _dbContext.ConversionsPrices.SingleOrDefault(e => e.ConversionsId == id);
            var expenses = HandlingMapperUtility.Map(expensesEntity);
            return expenses;
        }
    }
}
