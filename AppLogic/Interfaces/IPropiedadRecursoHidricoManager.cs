using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IPropiedadRecursoHidricoManager
    {
        void Create(PropiedadRecursoHidrico recurso);
        void Update(PropiedadRecursoHidrico recurso);
        void Delete(PropiedadRecursoHidrico recurso);
        List<PropiedadRecursoHidrico> RetrieveAll();
        List<PropiedadRecursoHidrico> RetrieveById(int id);
        List<PropiedadRecursoHidrico> RetrieveByPropiedadId(int idPropiedad);
    }
}
