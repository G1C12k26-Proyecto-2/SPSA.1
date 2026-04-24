using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ParametroCategoriaDTO
    {
        public string Categoria { get; set; }
        public List<ParametroDTO> Parametros { get; set; }

        public ParametroCategoriaDTO()
        {
            Categoria = string.Empty;
            Parametros = new List<ParametroDTO>();
        }
    }
}
