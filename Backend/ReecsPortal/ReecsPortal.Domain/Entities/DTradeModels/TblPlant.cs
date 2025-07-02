using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblPlant
{
    public int PlantCode { get; set; }

    public string? PlantName { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public string? PlantPickerCode { get; set; }

    public string Archived { get; set; } = null!;

    public string Psag { get; set; } = null!;

    public int? Active { get; set; }

    public string? Company { get; set; }
}
