using ProfitCalculation.Logic.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Services
{
    internal interface IOrderService
    {
        List<Order> GetAllOrders();
    }
}
