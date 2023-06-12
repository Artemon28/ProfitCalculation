using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.Logic.Materials.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Materials.Services
{
    internal class MaterialService: IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository orderRepository)
        {
            _materialRepository = orderRepository;
        }

        List<Material> IMaterialService.GetAllMaterials()
        {
            var materialModels = _materialRepository.GetAllMaterials();
            return materialModels;
        }
    }
}
