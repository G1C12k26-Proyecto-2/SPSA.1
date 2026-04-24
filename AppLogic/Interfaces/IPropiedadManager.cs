using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IPropiedadManager
    {
        void Create(Propiedad propiedad);
        void Update(Propiedad propiedad);
        void Delete(Propiedad propiedad);
        List<Propiedad> RetrieveAll();
        List<Propiedad> RetrieveById(int id);
        void CreateWithRecursos(PropiedadConRecursosDTO dto);
        List<PropiedadDetalleDTO> RetrieveAllWithDetail();

       List<PropiedadDetalleDTO> RetrieveByIdWithDetail(int id);
    }
}
