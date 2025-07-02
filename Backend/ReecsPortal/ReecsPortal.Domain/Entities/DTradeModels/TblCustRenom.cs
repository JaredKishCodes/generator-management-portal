using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblCustRenom
{
    public DateOnly? DelDate { get; set; }

    public int? DelFrom { get; set; }

    public int? DelTo { get; set; }

    public int? Approved { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? CustCode { get; set; }

    public string? Reason { get; set; }

    public double? Nvalue { get; set; }

    public double? OldValue { get; set; }

    public long Rid { get; set; }
}
