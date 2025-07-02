using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwTotalSettlePrice
{
    public DateOnly? DelDate { get; set; }

    public int? DelInterval { get; set; }

    public double? TsettlePrice { get; set; }
}
