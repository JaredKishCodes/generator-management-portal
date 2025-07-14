

using System.ComponentModel.DataAnnotations;

namespace ReecsPortal.Application.DTOs.Customer
{
    public class CustRequest
    {
        [Required]
        public string CustName { get; set; } = string.Empty;
        [Required]
        public string CustAddress { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string? CreatedBy { get; set; } 
        [Required]
        public string? CustFullName { get; set; }
        public string Archived { get; set; } = string.Empty;
        [Required]

        public double? DemandMw { get; set; }
        [Required]
        public double? RegPrice { get; set; }

    }
}


