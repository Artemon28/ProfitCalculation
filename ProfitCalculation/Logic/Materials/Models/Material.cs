using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Materials.Models
{
    internal class Material
    {
        public Material(long id, long code, string cipherName, int typeId, decimal? amount, decimal? price)
        {
            Id = id;
            Code = code;
            CipherName = cipherName;
            TypeId = typeId;
            Amount = amount;
            Price = price;
        }

        public long Id { get; }

        public long Code { get; }

        public string CipherName { get; }

        public int TypeId { get; }

        public decimal? Amount { get; }

        public decimal? Price { get; }

        public bool IsFinalProduct()
        {
            return TypeId == 2;
        }
    }
}
