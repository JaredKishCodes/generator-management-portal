using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblUserLog
{
    public DateTime? CreatedDate { get; set; }

    public string? Username { get; set; }

    public string? Activity { get; set; }

    public long RedId { get; set; }

    public string? Ip { get; set; }
}
