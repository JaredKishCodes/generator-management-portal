using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblPlantsCapacity
{
    public long PlantCapCode { get; set; }

    public int? PlantCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public double? Capacity { get; set; }

    public string Archived { get; set; } = null!;

    public DateOnly? Petsa { get; set; }

    public int? DelInterval { get; set; }

    public double? Price { get; set; }
}
