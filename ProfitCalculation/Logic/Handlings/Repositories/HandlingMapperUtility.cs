using ProfitCalculation.Logic.Handlings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;

namespace ProfitCalculation.Logic.Handlings.Repositories
{
    internal class HandlingMapperUtility
    {
        public static Handling Map(GuideCalculationMaterial calculation)
        {
            return new Handling
            (
                calculation.ConversionId,
                calculation.ReleaseId,
                calculation.CreatedForId,
                calculation.ExpenseRatio
            );
        }

        public static List<Handling> Map(List<GuideCalculationMaterial> calculations)
        {

            var handlings = new List<Handling>();
            foreach (var orderDetail in calculations)
            {
                handlings.Add(Map(orderDetail));
            }
            return handlings;
        }

        public static Expenses Map(BasicPricing pricing)
        {
            return new Expenses
            (
                pricing.ConversionId,
                pricing.CipherId,
                pricing.Wastes,
                pricing.AuxiliaryAdditionalExpenses,
                pricing.SpecialTreatment,
                pricing.Salary,
                pricing.SocialInsurance
            );
        }

        public static Dictionary<long, Expenses> Map(List<BasicPricing> pricings)
        {

            var expenses = new Dictionary<long, Expenses>();
            foreach (var pricing in pricings)
            {
                expenses.Add(pricing.CipherId, Map(pricing));
            }
            return expenses;
        }

        public static ConversionExpenses Map(ConversionsPrice pricing)
        {
            return new ConversionExpenses
            (
                pricing.ConversionsId,
                pricing.AvgPrice
            );
        }
    }
}
