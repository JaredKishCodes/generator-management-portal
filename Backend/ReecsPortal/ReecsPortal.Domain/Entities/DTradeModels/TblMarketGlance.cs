using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblMarketGlance
{
    public long? Id { get; set; }

    public DateTime? RunTime { get; set; }

    public DateTime? TimeInterval { get; set; }

    public string? MktType { get; set; }

    public string? RegionName { get; set; }

    public double? Suppy { get; set; }

    public double? Demand { get; set; }

    public double? Price { get; set; }

    public DateTime? DisplayTimeInterval { get; set; }
}
