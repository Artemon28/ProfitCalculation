using ProfitCalculation.Logic.Handlings.Models;
using ProfitCalculation.Logic.Handlings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Services
{
    internal class HandlingService: IHandlingService
    {
        private readonly IHandlingRepository _handlingRepository;

        public HandlingService(IHandlingRepository handlingRepository)
        {
            _handlingRepository = handlingRepository;
        }

        public decimal CalculateExpenses(long CipherId, int ConversionId)
        {
            var expenses = _handlingRepository.GetExpensesById(CipherId);
            return SumUpExpenses(expenses) + CalculateAddExpenses(ConversionId);
        }

        public decimal GetWastes(long CipherId)
        {
            var expenses = _handlingRepository.GetExpensesById(CipherId);
            if (expenses == null)
            {
                return 0;
            }
            return expenses.Wastes;
        }

        private decimal SumUpExpenses(Expenses? expenses)
        {
            if (expenses == null)
            {
                return 0;
            }
            return expenses.AuxiliaryAdditionalExpenses + expenses.SpecialTreatment +
                expenses.Salary + expenses.SocialInsurance;
        }

        private decimal CalculateAddExpenses(int ConversionId)
        {
            if (ConversionId == 0)
            {
                return 0;
            }
            return _handlingRepository.GetconversionExpensesById(ConversionId).AvgPrice;
        }

        List<Handling> IHandlingService.GetAllHandlings()
        {
            var handlingModels = _handlingRepository.GetAllHandlings();
            return handlingModels;
        }
    }
}
