using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReecsPortal.Application.DTOs
{
    public class UpdateGenRequest
    {   
       
        public int GenCode { get; set; }
        [Required]
        public string? GenName { get; set; }
        [Required]
        public string? GenAddress { get; set; }

        public string? CreatedBy { get; set; }
        
        public DateOnly? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public string? GenFullName { get; set; }

        public string Archived { get; set; } = "0";
        [Required]
        public int? CapacityMw { get; set; }
        [Required]
        public double? RegPrice { get; set; }
    }
}
