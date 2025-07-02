using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwEffrate
{
    public DateOnly? DelDate { get; set; }

    public int? DelInterval { get; set; }

    public double? Sp { get; set; }

    public double? Dem { get; set; }

    public double? EffRate { get; set; }
}
