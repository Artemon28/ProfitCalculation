using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Models
{
    internal class ConversionExpenses
    {
        public ConversionExpenses(int conversionsId, decimal avgPrice)
        {
            ConversionsId = conversionsId;
            AvgPrice = avgPrice;
        }

        public int ConversionsId { get; }

        public decimal AvgPrice { get; }
    }
}
