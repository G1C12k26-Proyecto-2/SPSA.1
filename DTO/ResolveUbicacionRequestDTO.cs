using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ResolveUbicacionRequestDTO : BaseClass
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
    }
}