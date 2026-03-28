using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
