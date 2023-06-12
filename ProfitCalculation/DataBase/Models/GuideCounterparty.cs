using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideCounterparty
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GuideContract> GuideContracts { get; set; } = new List<GuideContract>();

    public virtual ICollection<GuideOrdersHeader> GuideOrdersHeaderCargoRecipients { get; set; } = new List<GuideOrdersHeader>();

    public virtual ICollection<GuideOrdersHeader> GuideOrdersHeaderPayers { get; set; } = new List<GuideOrdersHeader>();
}
