using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwHvdcprice
{
    public DateTime? TimeInterval { get; set; }

    public string? TlName { get; set; }

    public double? MosysPrice { get; set; }

    public double? Mw { get; set; }
}
