using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class PropiedadManager : IPropiedadManager
    {
        private readonly PropiedadCrud _propiedadCrud;
        private readonly PropiedadRecursoHidricoCrud _recursoCrud;

        public PropiedadManager()
        {
            _propiedadCrud = new PropiedadCrud();
            _recursoCrud = new PropiedadRecursoHidricoCrud();
        }

        public void Create(Propiedad propiedad)
        {
            _propiedadCrud.Create(propiedad);
        }

        public void Update(Propiedad propiedad)
        {
            _propiedadCrud.Update(propiedad);
        }

        public void Delete(Propiedad propiedad)
        {
            _propiedadCrud.Delete(propiedad);
        }

        public List<Propiedad> RetrieveAll()
        {
            return _propiedadCrud.RetrieveAll<Propiedad>();
        }

        public List<Propiedad> RetrieveById(int id)
        {
            return _propiedadCrud.RetrieveById<Propiedad>(id);
        }

        public void CreateWithRecursos(PropiedadConRecursosDTO dto)
        {
            int newPropiedadId = _propiedadCrud.CreateAndReturnId(dto.Propiedad);

            if (dto.RecursosHidricos != null && dto.RecursosHidricos.Count > 0)
            {
                foreach (var recurso in dto.RecursosHidricos)
                {
                    recurso.IdPropiedad = newPropiedadId;
                    _recursoCrud.Create(recurso);
                }
            }
        }

        public List<PropiedadDetalleDTO> RetrieveAllWithDetail()
        {
            var propiedades = _propiedadCrud.RetrieveAll<Propiedad>();
            var resultados = new List<PropiedadDetalleDTO>();

            foreach (var propiedad in propiedades)
            {
                var detalle = new PropiedadDetalleDTO
                {
                    Id = propiedad.Id,
                    Active = propiedad.Active,
                    IdSolicitud = propiedad.IdSolicitud,
                    AreaHectareas = propiedad.AreaHectareas,
                    VegetacionClave = propiedad.VegetacionClave,
                    PendienteClave = propiedad.PendienteClave,
                    ValorCalculado = propiedad.ValorCalculado,
                    FechaUltimaValuacion = propiedad.FechaUltimaValuacion,
                    FechaCreacion = propiedad.FechaCreacion,
                    FechaActualizacion = propiedad.FechaActualizacion,
                    UsuarioCreacionId = propiedad.UsuarioCreacionId,
                    UsuarioActualizaId = propiedad.UsuarioActualizaId,
                    RecursosHidricos = _recursoCrud.RetrieveByPropiedadId<PropiedadRecursoHidrico>(propiedad.Id)
                };

                resultados.Add(detalle);
            }

            return resultados;
        }

        public List<PropiedadDetalleDTO> RetrieveByIdWithDetail(int id)
        {
            var propiedades = _propiedadCrud.RetrieveById<Propiedad>(id);
            var resultados = new List<PropiedadDetalleDTO>();

            foreach (var propiedad in propiedades)
            {
                var detalle = new PropiedadDetalleDTO
                {
                    Id = propiedad.Id,
                    Active = propiedad.Active,
                    IdSolicitud = propiedad.IdSolicitud,
                    AreaHectareas = propiedad.AreaHectareas,
                    VegetacionClave = propiedad.VegetacionClave,
                    PendienteClave = propiedad.PendienteClave,
                    ValorCalculado = propiedad.ValorCalculado,
                    FechaUltimaValuacion = propiedad.FechaUltimaValuacion,
                    FechaCreacion = propiedad.FechaCreacion,
                    FechaActualizacion = propiedad.FechaActualizacion,
                    UsuarioCreacionId = propiedad.UsuarioCreacionId,
                    UsuarioActualizaId = propiedad.UsuarioActualizaId,
                    RecursosHidricos = _recursoCrud.RetrieveByPropiedadId<PropiedadRecursoHidrico>(propiedad.Id)
                };

                resultados.Add(detalle);
            }

            return resultados;
        }
    }
}