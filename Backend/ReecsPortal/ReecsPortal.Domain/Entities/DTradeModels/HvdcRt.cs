using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class HvdcRt
{
    public DateTime? DelDate { get; set; }

    public double? Load { get; set; }

    public long Rid { get; set; }

    public string? TlName { get; set; }
}
