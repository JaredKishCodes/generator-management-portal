using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwGenMatrix
{
    public int? Usercode { get; set; }

    public int GenCode { get; set; }

    public string? GenName { get; set; }

    public string? GenAddress { get; set; }

    public string? GenFullName { get; set; }

    public string Archived { get; set; } = null!;

    public int? CapacityMw { get; set; }

    public double? RegPrice { get; set; }

    public int? Approved { get; set; }

    public int? MatrixArchived { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactNum { get; set; }

    public string? ContactAddress { get; set; }

    public string Username { get; set; } = null!;
}
