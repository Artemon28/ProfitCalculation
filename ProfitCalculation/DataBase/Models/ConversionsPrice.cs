using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfitCalculation.DataBase.Models;

public partial class ConversionsPrice
{
    public int ConversionsId { get; set; }

    public decimal AvgPrice { get; set; }

    public virtual GuideConversion Conversions { get; set; } = null!;
}
