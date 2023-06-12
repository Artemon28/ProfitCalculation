using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Models
{
    internal class Handling
    {
        public Handling()
        {
            
        }
        public Handling(int? conversionId, long releaseId, long? createdForId, decimal? expenseRatio)
        {
            ConversionId = conversionId;
            ReleaseId = releaseId;
            CreatedForId = createdForId;
            ExpenseRatio = expenseRatio;
        }

        public int? ConversionId { get; }

        public long ReleaseId { get; }

        public long? CreatedForId { get; set; }

        public decimal? ExpenseRatio { get; }
        public class HandlingComparer : IComparer<Handling>
        {
            int IComparer<Handling>.Compare(Handling x, Handling y)
            {
                if (x.CreatedForId > y.CreatedForId)
                {
                    return 1;
                }
                else if (x.CreatedForId == y.CreatedForId)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
