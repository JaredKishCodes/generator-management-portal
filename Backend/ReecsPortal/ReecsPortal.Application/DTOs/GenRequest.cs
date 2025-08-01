﻿

using System.ComponentModel.DataAnnotations;

namespace ReecsPortal.Application.DTOs
{
    public class GenRequest
    {

        [Required]
        public string GenName { get; set; } = string.Empty;
        [Required]
        public string GenAddress { get; set; } = string.Empty;

        public string? CreatedBy { get; set; }
        
        public DateOnly? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public string? GenFullName { get; set; }

        public string Archived { get; set; } = string.Empty;
        [Required]
        public int? CapacityMw { get; set; }
        [Required]
        public double? RegPrice { get; set; }
    }
}
