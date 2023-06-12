using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideCipher
{
    public long Id { get; set; }

    public long Code { get; set; }

    public string CipherName { get; set; } = null!;

    public int TypeId { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<GuideOrdersDetail> GuideOrdersDetails { get; set; } = new List<GuideOrdersDetail>();
    public virtual ICollection<ResultChain> ResultChainRelease { get; set; } = new List<ResultChain>();
    public virtual ICollection<ResultChain> ResultChainCreatedFor { get; set; } = new List<ResultChain>();
    public virtual ICollection<ResultChain> ResultBaseMaterial { get; set; } = new List<ResultChain>();
    
    public virtual GuideType Type { get; set; } = null!;
}
