using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideOrdersDetail
{
    public int Id { get; set; }

    public int HeaderId { get; set; }

    public long CipherId { get; set; }

    public int UnitsMeasurementId { get; set; }

    public string Specifications { get; set; } = null!;

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public int CurrencyId { get; set; }

    public DateTime DeliveryDate { get; set; }

    public virtual GuideCipher Cipher { get; set; } = null!;

    public virtual GuideCurrency Currency { get; set; } = null!;

    public virtual GuideOrdersHeader Header { get; set; } = null!;

    public virtual GuideUnitsMeasurement UnitsMeasurement { get; set; } = null!;
}
