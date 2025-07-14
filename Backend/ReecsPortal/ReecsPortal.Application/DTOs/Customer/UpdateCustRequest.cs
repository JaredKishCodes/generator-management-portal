

namespace ReecsPortal.Application.DTOs.Customer
{
    public class UpdateCustRequest
    {
        public int CustCode { get; set; }

        public string? CustName { get; set; }

        public string? CustAddress { get; set; }

        public string? ModifiedBy { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public string? CustFullName { get; set; }

        public string Archived { get; set; } = "0";

        public double? DemandMw { get; set; }

        public double? RegPrice { get; set; }
    }
}
