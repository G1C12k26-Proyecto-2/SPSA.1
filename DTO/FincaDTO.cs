using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class FincaDTO : BaseClass
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int LocationId { get; set; }
    }
}
