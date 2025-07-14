

namespace ReecsPortal.Application.DTOs.Customer
{
    public class CustResponse
    {
        public int CustCode { get; set; }
        public string CustName { get; set; } = string.Empty;
        public string CustAddress { get; set; } = string.Empty;
        public double? DemandMw { get; set; }

        public double? RegPrice { get; set; }
    }
}
