using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class User : BaseClass
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
    }
}
