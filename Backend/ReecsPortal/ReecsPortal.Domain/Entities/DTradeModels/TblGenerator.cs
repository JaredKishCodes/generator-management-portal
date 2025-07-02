using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblGenerator
{
    public int GenCode { get; set; }

    public string? GenName { get; set; }

    public string? GenAddress { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public string? GenFullName { get; set; }

    public string Archived { get; set; } = null!;

    public int? CapacityMw { get; set; }

    public double? RegPrice { get; set; }
}
