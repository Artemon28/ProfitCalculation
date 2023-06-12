using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideWorkshop
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string WorkshopName { get; set; } = null!;

    public virtual ICollection<GuideConversion> GuideConversions { get; set; } = new List<GuideConversion>();
}
