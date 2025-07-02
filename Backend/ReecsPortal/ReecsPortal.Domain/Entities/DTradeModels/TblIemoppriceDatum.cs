using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblIemoppriceDatum
{
    public long Rid { get; set; }

    public string? ParamName { get; set; }

    public int? Supply { get; set; }

    public int? Demand { get; set; }

    public int? Price { get; set; }

    public DateTime? DelInterval { get; set; }
}
