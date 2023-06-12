using ProfitCalculation.Logic.Orders.Models;
using ProfitCalculation.Logic.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        List<Order> IOrderService.GetAllOrders()
        {
            var orderModels = _orderRepository.GetAllOrders();
            return orderModels;
        }
    }
}
