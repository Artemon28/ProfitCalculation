using System;
using System.Collections.Generic;

namespace ProfitCalculation.DataBase.Models;

public partial class GuideType
{
    public string TypeName { get; set; } = null!;

    public string TypeShort { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<GuideCipher> GuideCiphers { get; set; } = new List<GuideCipher>();
}
