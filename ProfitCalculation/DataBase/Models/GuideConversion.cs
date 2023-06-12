using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideConversion
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string ConversionName { get; set; } = null!;

    public int WorkshopId { get; set; }

    public virtual GuideWorkshop Workshop { get; set; } = null!;

    public virtual ICollection<ResultChain> ResultChains { get; set; } = new List<ResultChain>();
}
