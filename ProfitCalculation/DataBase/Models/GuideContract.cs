using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideContract
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int Year { get; set; }

    public int СounterpartyId { get; set; }

    public virtual ICollection<GuideOrdersHeader> GuideOrdersHeaders { get; set; } = new List<GuideOrdersHeader>();

    public virtual GuideCounterparty Сounterparty { get; set; } = null!;
}
