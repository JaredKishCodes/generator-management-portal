using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwLoadDispatch
{
    public string? CustName { get; set; }

    public long? ProfileCode { get; set; }

    public int? CustCode { get; set; }

    public DateOnly? DelDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? DelInterval { get; set; }

    public int? DelType { get; set; }

    public double? DelMw { get; set; }

    public int? Archived { get; set; }

    public int? IsForecast { get; set; }

    public string? Fo { get; set; }

    public string? Mo { get; set; }

    public string? Wd { get; set; }

    public int? Pcode { get; set; }

    public double? DelInterval5 { get; set; }

    public double? RegPrice { get; set; }

    public int? Usercode { get; set; }
}
