using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwMosysPrice
{
    public DateTime? TimeInterval { get; set; }

    public double? MosysPrice { get; set; }
}
