using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwNom
{
    public int? PlantCode { get; set; }

    public DateOnly? DelDate { get; set; }

    public int? DelInterval { get; set; }

    public double? DelMw { get; set; }

    public int? Archived { get; set; }

    public string? Confirmed { get; set; }

    public long? NomCode { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? IsSubmitted { get; set; }

    public string? GenName { get; set; }

    public double? RegPrice { get; set; }

    public int? Usercode { get; set; }
}
