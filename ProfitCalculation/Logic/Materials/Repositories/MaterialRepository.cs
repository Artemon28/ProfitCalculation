using Microsoft.EntityFrameworkCore;
using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Materials.Repositories
{
    internal class MaterialRepository : IMaterialRepository
    {
        private readonly ProfitCalculatingContext _dbContext;

        public MaterialRepository(ProfitCalculatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Material> GetAllMaterials()
        {
            var materialEntities = _dbContext.GuideCiphers.ToList();
            var orders = MaterialMapperUtility.Map(materialEntities);
            return orders;
        }
    }
}
