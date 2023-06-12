using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Models
{
    internal class Expenses
    {
        public Expenses(int? conversionId, long cipherId, decimal? wastes, decimal? auxiliaryAdditionalExpenses, decimal? specialTreatment, decimal? salary, decimal? socialInsurance)
        {
            ConversionId = conversionId;
            CipherId = cipherId;
            Wastes = (wastes ?? 0);
            AuxiliaryAdditionalExpenses = (auxiliaryAdditionalExpenses ?? 0);
            SpecialTreatment = (specialTreatment ?? 0);
            Salary = (salary ?? 0);
            SocialInsurance = (socialInsurance ?? 0);
        }

        public int? ConversionId { get; set; }

        public long CipherId { get; set; }

        public decimal Wastes { get; set; }

        public decimal AuxiliaryAdditionalExpenses { get; set; }

        public decimal SpecialTreatment { get; set; }

        public decimal Salary { get; set; }

        public decimal SocialInsurance { get; set; }
    }
}
