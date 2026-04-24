using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mappers
{
    public class PropiedadRecursoHidricoMapper : IObjectMapper, ICrudStatements
    {
        public PropiedadRecursoHidrico BuildSingleObject(List<Dictionary<string, object>> rows)
        {
            if (rows.Count == 0)
                return null;

            return (PropiedadRecursoHidrico)BuildObject(rows[0]);
        }

        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var recurso = new PropiedadRecursoHidrico();

            recurso.Id = int.Parse(row["Id"].ToString());
            recurso.Active = bool.Parse(row["Active"].ToString());
            recurso.IdPropiedad = int.Parse(row["IdPropiedad"].ToString());
            recurso.RecursoHidricoClave = row["RecursoHidricoClave"].ToString();
            recurso.Cantidad = int.Parse(row["Cantidad"].ToString());

            if (row.ContainsKey("FechaCreacion") && row["FechaCreacion"] != null && row["FechaCreacion"] != DBNull.Value)
            {
                recurso.FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString());
            }

            if (row.ContainsKey("FechaActualizacion") && row["FechaActualizacion"] != null && row["FechaActualizacion"] != DBNull.Value)
            {
                recurso.FechaActualizacion = DateTime.Parse(row["FechaActualizacion"].ToString());
            }

            if (row.ContainsKey("UsuarioCreacionId") && row["UsuarioCreacionId"] != null && row["UsuarioCreacionId"] != DBNull.Value)
            {
                recurso.UsuarioCreacionId = int.Parse(row["UsuarioCreacionId"].ToString());
            }

            if (row.ContainsKey("UsuarioActualizaId") && row["UsuarioActualizaId"] != null && row["UsuarioActualizaId"] != DBNull.Value)
            {
                recurso.UsuarioActualizaId = int.Parse(row["UsuarioActualizaId"].ToString());
            }

            return recurso;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();

            foreach (var item in rows)
            {
                results.Add(BuildObject(item));
            }

            return results;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var recurso = (PropiedadRecursoHidrico)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_PROPIEDAD_RECURSO_HIDRICO"
            };

            operation.AddIntParam("IdPropiedad", recurso.IdPropiedad);
            operation.AddVarcharParam("RecursoHidricoClave", recurso.RecursoHidricoClave);
            operation.AddIntParam("Cantidad", recurso.Cantidad);
            operation.AddIntParam("Active", recurso.Active ? 1 : 0);

            if (recurso.UsuarioCreacionId.HasValue)
            {
                operation.AddIntParam("UsuarioCreacionId", recurso.UsuarioCreacionId.Value);
            }

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PROPIEDAD_RECURSO_HIDRICO_BY_ID"
            };

            operation.AddIntParam("Id", pId);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_ALL_PROPIEDAD_RECURSO_HIDRICO"
            };

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            var recurso = (PropiedadRecursoHidrico)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_UPDATE_PROPIEDAD_RECURSO_HIDRICO"
            };

            operation.AddIntParam("Id", recurso.Id);
            operation.AddIntParam("IdPropiedad", recurso.IdPropiedad);
            operation.AddVarcharParam("RecursoHidricoClave", recurso.RecursoHidricoClave);
            operation.AddIntParam("Cantidad", recurso.Cantidad);
            operation.AddIntParam("Active", recurso.Active ? 1 : 0);

            if (recurso.UsuarioActualizaId.HasValue)
            {
                operation.AddIntParam("UsuarioActualizaId", recurso.UsuarioActualizaId.Value);
            }

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            var recurso = (PropiedadRecursoHidrico)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_DELETE_PROPIEDAD_RECURSO_HIDRICO"
            };

            operation.AddIntParam("Id", recurso.Id);

            return operation;
        }

        public SqlOperation GetRetrieveByPropiedadIdStatement(int idPropiedad)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_RECURSOS_HIDRICOS_BY_PROPIEDAD_ID"
            };

            operation.AddIntParam("IdPropiedad", idPropiedad);

            return operation;
        }
    }
}