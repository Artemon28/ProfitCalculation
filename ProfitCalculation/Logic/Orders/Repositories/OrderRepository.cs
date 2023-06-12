using Microsoft.EntityFrameworkCore;
using ProfitCalculation.Logic.Orders.Models;
using ProfitCalculation.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Orders.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ProfitCalculatingContext _dbContext;

        public OrderRepository(ProfitCalculatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAllOrders()
        {
            var orderEntities = _dbContext.GuideOrdersHeaders.Include(o => o.GuideOrdersDetails).ToList();
            var orders = OrderMapperUtility.Map(orderEntities);
            return orders;
        }
    }
}
