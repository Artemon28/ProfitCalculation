using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideOrdersHeader
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int Year { get; set; }

    public int ContractId { get; set; }

    public int CargoRecipientId { get; set; }

    public int PayerId { get; set; }

    public virtual GuideCounterparty CargoRecipient { get; set; } = null!;

    public virtual GuideContract Contract { get; set; } = null!;

    public virtual ICollection<GuideOrdersDetail> GuideOrdersDetails { get; set; } = new List<GuideOrdersDetail>();

    public virtual GuideCounterparty Payer { get; set; } = null!;
}
