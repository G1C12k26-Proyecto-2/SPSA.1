using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ResetPasswordDTO
    {
        public string Token { get; set; }        // RAW token from email
        public string NewPassword { get; set; }
    }
}
