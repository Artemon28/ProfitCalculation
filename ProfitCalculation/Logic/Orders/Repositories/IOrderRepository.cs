using ProfitCalculation.Logic.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Repositories
{
    internal interface IOrderRepository
    {
        List<Order> GetAllOrders();
    }
}
