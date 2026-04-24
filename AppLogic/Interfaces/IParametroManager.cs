using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IParametroManager
    {
        void Create(ParametroDTO parametro);
        void UpdateParametro(ParametroUpdateDTO dto);
        List<ParametroDTO> RetrieveAll();
        List<ParametroDTO> RetrieveById(int id);
        List<ParametroDTO> RetrieveByCategoria(string categoria);
        List<ParametroDTO> RetrieveByClave(string clave);
    }
}
