using System;
using System.Collections.Generic;

namespace ReecsPortal.Infrastructure.DTradeModels;

public partial class VwUser
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? CustCode { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public string? CustFullName { get; set; }

    public int Usercode { get; set; }

    public string? AccessLevel { get; set; }

    public int? Pgroup { get; set; }

    public string? Verified { get; set; }
}
