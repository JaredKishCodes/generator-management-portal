using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwRtdbill
{
    public long NomCode { get; set; }

    public int? PlantCode { get; set; }

    public int? CustCode { get; set; }

    public DateOnly? DelDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? IsSubmitted { get; set; }

    public int? DelInterval { get; set; }

    public int? DelType { get; set; }

    public double? DelMw { get; set; }

    public int? Archived { get; set; }

    public string? Status { get; set; }

    public string? Confirmed { get; set; }

    public double? DelInterval5 { get; set; }

    public int? Renom { get; set; }

    public int? IntervalId { get; set; }

    public double? Price { get; set; }

    public string? GenName { get; set; }
}
