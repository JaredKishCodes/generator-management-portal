using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblGenMatrix
{
    public int Rid { get; set; }

    public int? Usercode { get; set; }

    public int? GenCode { get; set; }

    public int? Archived { get; set; }

    public int? Approved { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public DateOnly? ModifiedDate { get; set; }
}
