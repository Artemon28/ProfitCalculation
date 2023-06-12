using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Models
{
    internal class Order
    {
        public Order(int id, int number, int year, int contractId, int cargoRecipientId, int payerId, List<OrderDetail> orderDetails)
        {
            Id = id;
            Number = number;
            Year = year;
            ContractId = contractId;
            CargoRecipientId = cargoRecipientId;
            PayerId = payerId;
            OrderDetails = orderDetails;
        }

        public int Id { get; }

        private int Number { get; }

        public int Year { get; }

        private int ContractId { get; }

        private int CargoRecipientId { get; }

        private int PayerId { get; }

        public List<OrderDetail> OrderDetails { get; }
    }
}
