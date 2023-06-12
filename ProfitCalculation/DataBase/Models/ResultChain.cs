using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.DataBase.Models
{
    public partial class ResultChain : PlainChain
    {

        public virtual GuideConversion? Conversion { get; set; } = null!;
        public virtual GuideCipher? CreatedFor { get; set; }
        public virtual GuideCipher Release { get; set; } = null!;
        public virtual GuideCipher? BaseMaterial { get; set; }
    }
}
