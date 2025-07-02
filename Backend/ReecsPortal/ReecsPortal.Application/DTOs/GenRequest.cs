

using System.ComponentModel.DataAnnotations;

namespace ReecsPortal.Application.DTOs
{
    public class GenRequest
    {

        [Required]
        public string? GenName { get; set; }
        [Required]
        public string? GenAddress { get; set; }

        public string? CreatedBy { get; set; }
        [Required]
        public DateOnly? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public string? GenFullName { get; set; }

        public string Archived { get; set; } = null!;
        [Required]
        public int? CapacityMw { get; set; }
        [Required]
        public double? RegPrice { get; set; }
    }
}
