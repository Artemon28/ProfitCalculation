using ProfitCalculation.Logic.Materials.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;

namespace ProfitCalculation.Logic.Materials.Repositories
{
    internal class MaterialMapperUtility
    {
        public static Material Map(GuideCipher cipher)
        {
            return new Material
            (
                cipher.Id,
                cipher.Code,
                cipher.CipherName,
                cipher.TypeId,
                cipher.Amount,
                cipher.Price
            );
        }

        public static List<Material> Map(List<GuideCipher> ciphers)
        {

            var materials = new List<Material>();
            foreach (var orderDetail in ciphers)
            {
                materials.Add(Map(orderDetail));
            }
            return materials;
        }
    }
}
