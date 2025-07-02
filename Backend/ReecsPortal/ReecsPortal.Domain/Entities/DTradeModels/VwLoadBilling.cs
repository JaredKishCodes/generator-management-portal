using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwLoadBilling
{
    public DateOnly? DelDate { get; set; }

    public int? CustCode { get; set; }

    public double? DelMw { get; set; }

    public string? CustName { get; set; }

    public double? EffRate { get; set; }

    public double? DelInterval5 { get; set; }
}
