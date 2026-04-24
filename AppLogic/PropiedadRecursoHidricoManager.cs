using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class PropiedadRecursoHidricoManager : IPropiedadRecursoHidricoManager
    {
        private readonly PropiedadRecursoHidricoCrud _recursoCrud;

        public PropiedadRecursoHidricoManager()
        {
            _recursoCrud = new PropiedadRecursoHidricoCrud();
        }

        public void Create(PropiedadRecursoHidrico recurso)
        {
            _recursoCrud.Create(recurso);
        }

        public void Update(PropiedadRecursoHidrico recurso)
        {
            _recursoCrud.Update(recurso);
        }

        public void Delete(PropiedadRecursoHidrico recurso)
        {
            _recursoCrud.Delete(recurso);
        }

        public List<PropiedadRecursoHidrico> RetrieveAll()
        {
            return _recursoCrud.RetrieveAll<PropiedadRecursoHidrico>();
        }

        public List<PropiedadRecursoHidrico> RetrieveById(int id)
        {
            return _recursoCrud.RetrieveById<PropiedadRecursoHidrico>(id);
        }

        public List<PropiedadRecursoHidrico> RetrieveByPropiedadId(int idPropiedad)
        {
            return _recursoCrud.RetrieveByPropiedadId<PropiedadRecursoHidrico>(idPropiedad);
        }
    }
}
