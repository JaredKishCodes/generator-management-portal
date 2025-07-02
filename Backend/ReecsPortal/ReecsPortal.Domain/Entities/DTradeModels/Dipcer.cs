using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class Dipcer
{
    public DateTime? TimeInterval { get; set; }

    public string? RegionName { get; set; }

    public string? ResourceName { get; set; }

    public string? PricingFlag { get; set; }

    public double? Lmp { get; set; }

    public double? SchedMw { get; set; }

    public double? LmpSmp { get; set; }

    public double? LmpLoss { get; set; }

    public double? LmpCongestion { get; set; }
}
