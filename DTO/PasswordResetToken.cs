using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PasswordResetToken : BaseClass
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenHash { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
    }
}
