using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReecsPortal.Application.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

    }
}
