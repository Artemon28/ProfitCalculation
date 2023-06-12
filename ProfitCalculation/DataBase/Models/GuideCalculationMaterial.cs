using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideCalculationMaterial
{
    public int Id { get; set; }
    public int? MainSign { get; set; }

    public int? ConversionId { get; set; }

    public long ReleaseId { get; set; }

    public long? CreatedForId { get; set; }

    public decimal? ExpenseRatio { get; set; }

    public decimal? LaborIntensityRatio { get; set; }

    public virtual GuideConversion? Conversion { get; set; }

    public virtual GuideCipher? CreatedFor { get; set; }

    public virtual GuideCipher Release { get; set; } = null!;
}
