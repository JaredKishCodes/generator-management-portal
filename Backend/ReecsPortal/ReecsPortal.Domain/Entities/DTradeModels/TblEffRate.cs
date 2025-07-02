using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblEffRate
{
    public long PriceId { get; set; }

    public DateOnly? DelDate { get; set; }

    public int? DelInterval5 { get; set; }

    public int? DelInterval { get; set; }
}
