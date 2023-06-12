using ProfitCalculation.Logic.Orders.Models;
using ProfitCalculation.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Repositories
{
    internal class OrderMapperUtility
    {
        public static OrderDetail Map(GuideOrdersDetail orderDetail)
        {
            return new OrderDetail
            (
                orderDetail.Id,
                orderDetail.CipherId,
                orderDetail.UnitsMeasurementId,
                orderDetail.Specifications,
                orderDetail.Amount,
                orderDetail.Price,
                orderDetail.CurrencyId,
                orderDetail.DeliveryDate
            );
        }

        public static List<OrderDetail> Map(List<GuideOrdersDetail> orderDeatails)
        {

            var orderDetails = new List<OrderDetail>();
            foreach (var orderDetail in orderDeatails)
            {
                orderDetails.Add(Map(orderDetail));
            }
            return orderDetails;
        }


        public static Order Map(GuideOrdersHeader orderHeader)
        {
            return new Order
            (
                orderHeader.Id,
                orderHeader.Number,
                orderHeader.Year,
                orderHeader.ContractId,
                orderHeader.CargoRecipientId,
                orderHeader.PayerId,
                Map((List<GuideOrdersDetail>)orderHeader.GuideOrdersDetails)
            );
        }

        public static List<Order> Map(List<GuideOrdersHeader> orderHeaders)
        {
            var orders = new List<Order>();
            foreach (var orderHeader in orderHeaders)
            {
                orders.Add(Map(orderHeader));
            }
            return orders;
        }
    }
}
