using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblMarketPriceForecast
{
    public string? ResourceName { get; set; }

    public DateTime? TimeInterval { get; set; }

    public double? Lmp { get; set; }
}
