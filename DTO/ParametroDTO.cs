using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ParametroDTO : BaseClass
    {
        public string Categoria { get; set; }
        public string Clave { get; set; }
        public string Valor { get; set; }
        public string TipoDato { get; set; }
        public string Descripcion { get; set; }
        public int OrdenVisual { get; set; }
        public bool EsEditable { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public int? UsuarioCreacionId { get; set; }
        public int? UsuarioActualizaId { get; set; }

        public ParametroDTO()
        {
            Categoria = string.Empty;
            Clave = string.Empty;
            Valor = string.Empty;
            TipoDato = string.Empty;
            Descripcion = string.Empty;
            Active = true;
            EsEditable = true;
        }
    }
}
