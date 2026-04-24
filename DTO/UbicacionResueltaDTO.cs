using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UbicacionResueltaDTO : BaseClass
    {
        public int? IdProvincia { get; set; }
        public int? IdCanton { get; set; }
        public int? IdDistrito { get; set; }
    }
}