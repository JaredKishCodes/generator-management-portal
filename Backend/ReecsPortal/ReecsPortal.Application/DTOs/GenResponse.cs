

using System.ComponentModel.DataAnnotations;

namespace ReecsPortal.Application.DTOs
{
    public class GenResponse
    {
        public int GenCode { get; set; }
        public string? GenName { get; set; }
        
        public string? GenAddress { get; set; }        
        public int? CapacityMw { get; set; }
        
        public double? RegPrice { get; set; }
    }
}
