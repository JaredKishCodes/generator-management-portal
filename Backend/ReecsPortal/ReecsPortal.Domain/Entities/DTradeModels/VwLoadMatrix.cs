using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwLoadMatrix
{
    public string Username { get; set; } = null!;

    public int? Usercode { get; set; }

    public int? MatrixArchived { get; set; }

    public int? Approved { get; set; }

    public int CustCode { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public string? CustFullName { get; set; }

    public string Archived { get; set; } = null!;

    public double? DemandMw { get; set; }

    public double? RegPrice { get; set; }

    public string? ContactNum { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactAddress { get; set; }
}
