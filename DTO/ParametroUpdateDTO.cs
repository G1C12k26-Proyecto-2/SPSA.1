using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ParametroUpdateDTO
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int? UsuarioActualizaId { get; set; }

        public ParametroUpdateDTO()
        {
            Valor = string.Empty;
        }
    }
}
