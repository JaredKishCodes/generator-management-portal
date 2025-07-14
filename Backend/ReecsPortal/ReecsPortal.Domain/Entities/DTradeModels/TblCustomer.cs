

namespace ReecsPortal.Domain.DTradeModels;

public partial class TblCustomer
{
    public int CustCode { get; set; }

    public string? CustName { get; set; }

    public string? CustAddress { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public string? CustFullName { get; set; }

    public string Archived { get; set; } = null!;

    public double? DemandMw { get; set; }

    public double? RegPrice { get; set; }
}
