using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfitCalculation.DataBase.Models;

public partial class BasicPricing
{
    public int? ConversionId { get; set; }
    public long CipherId { get; set; }
    public decimal? Wastes { get; set; }
    public decimal? AuxiliaryAdditionalExpenses { get; set; }
    public decimal? SpecialTreatment { get; set; }
    public decimal? Salary { get; set; }
    public decimal? SocialInsurance { get; set; }
    public virtual GuideCipher Cipher { get; set; } = null!;
    public virtual GuideConversion? Conversion { get; set; }
}
