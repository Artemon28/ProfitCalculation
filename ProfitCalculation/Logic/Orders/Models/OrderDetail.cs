using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Models
{
    internal class OrderDetail
    {
        public OrderDetail(int id, long cipherId, int unitsMeasurementId, string specifications, int amount, decimal price, int currencyId, DateTime deliveryDate)
        {
            Id = id;
            CipherId = cipherId;
            UnitsMeasurementId = unitsMeasurementId;
            Specifications = specifications;
            Amount = amount;
            Price = price;
            CurrencyId = currencyId;
            DeliveryDate = deliveryDate;
        }

        public int Id { get; set; }

        public long CipherId { get; set; }

        public int UnitsMeasurementId { get; set; }

        public string Specifications { get; set; } = null!;

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int CurrencyId { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
