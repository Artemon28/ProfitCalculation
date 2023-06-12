using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideUnitsMeasurement
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<GuideOrdersDetail> GuideOrdersDetails { get; set; } = new List<GuideOrdersDetail>();
}
