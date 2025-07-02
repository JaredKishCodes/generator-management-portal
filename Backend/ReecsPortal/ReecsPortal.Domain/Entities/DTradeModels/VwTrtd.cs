using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwTrtd
{
    public DateOnly? DelDate { get; set; }

    public int? DelInterval { get; set; }

    public double? Trtd { get; set; }
}
