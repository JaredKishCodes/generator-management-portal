using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwPlantloading
{
    public string? PlantName { get; set; }

    public int? PlantLoadingCode { get; set; }

    public int? PlantCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public double? Load { get; set; }

    public DateOnly? Petsa { get; set; }

    public string? Archived { get; set; }

    public int? DelInterval { get; set; }

    public double? Price { get; set; }
}
