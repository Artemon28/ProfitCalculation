using ProfitCalculation.Logic.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.OrderRealizer.Models
{
    internal class Portfol
    {
        public Portfol(OrderDetail detail, long baseMaterialId, decimal endCost)
        {
            this.detail = detail;
            this.baseMaterialId = baseMaterialId;
            this.endCost = endCost;
        }

        public OrderDetail detail { get; set; }
        public long baseMaterialId { get; set; }
        public decimal endCost { get; set; }
    }
}
