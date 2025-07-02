using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReecsPortal.Domain.Entities;

namespace ReecsPortal.Application.DTOs.Auth
{
    public class RegisterDto
    {
       

        [Required]
        [StringLength(100)]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]        
        public string? ContactAddress { get; set; }

        [Required]
        [Phone]
        public string? ContactNumber { get; set; }

        [Required]
        public string AccessType { get; set; }

        [Column("ContactEmail")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
