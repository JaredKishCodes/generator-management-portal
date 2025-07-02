using System;
using System.Collections.Generic;
using ReecsPortal.Domain.Entities;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class TblUser  
{
    public int Usercode { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? CustCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? AccessType { get; set; }

    public int? Pgroup { get; set; }

    public string? ContactNum { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactAddress { get; set; }

    public string? Verified { get; set; }
}
