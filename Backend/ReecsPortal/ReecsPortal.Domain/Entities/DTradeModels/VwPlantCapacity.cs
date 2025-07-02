using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwPlantCapacity
{
    public double? Capacity { get; set; }

    public DateOnly? Petsa { get; set; }

    public int? DelInterval { get; set; }

    public int? DelIntervalHr { get; set; }

    public string Archived { get; set; } = null!;

    public int GenCode { get; set; }

    public string? GenName { get; set; }

    public int? PlantCode { get; set; }

    public int? Usercode { get; set; }

    public double? Price { get; set; }
}
