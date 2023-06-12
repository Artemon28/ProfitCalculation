using ProfitCalculation.Logic.Materials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Materials.Repositories
{
    internal interface IMaterialRepository
    {
        List<Material> GetAllMaterials();
    }
}
