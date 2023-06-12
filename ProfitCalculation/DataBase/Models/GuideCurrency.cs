using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideCurrency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public decimal Exchange { get; set; }

    public virtual ICollection<GuideOrdersDetail> GuideOrdersDetails { get; set; } = new List<GuideOrdersDetail>();
}
