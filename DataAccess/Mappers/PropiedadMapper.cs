using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mappers
{
    public class PropiedadMapper : IObjectMapper, ICrudStatements
    {
        public Propiedad BuildSingleObject(List<Dictionary<string, object>> rows)
        {
            if (rows.Count == 0)
                return null;

            return (Propiedad)BuildObject(rows[0]);
        }

        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var propiedad = new Propiedad();

            propiedad.Id = int.Parse(row["Id"].ToString());
            propiedad.Active = Convert.ToBoolean(row["Active"]);
            propiedad.IdSolicitud = int.Parse(row["IdSolicitud"].ToString());
            propiedad.AreaHectareas = decimal.Parse(row["AreaHectareas"].ToString());
            propiedad.VegetacionClave = row["VegetacionClave"].ToString();
            propiedad.PendienteClave = row["PendienteClave"].ToString();

            if (row.ContainsKey("ValorCalculado") &&
                row["ValorCalculado"] != null &&
                row["ValorCalculado"] != DBNull.Value)
            {
                propiedad.ValorCalculado = decimal.Parse(row["ValorCalculado"].ToString());
            }

            if (row.ContainsKey("FechaUltimaValuacion") &&
                row["FechaUltimaValuacion"] != null &&
                row["FechaUltimaValuacion"] != DBNull.Value)
            {
                propiedad.FechaUltimaValuacion = DateTime.Parse(row["FechaUltimaValuacion"].ToString());
            }

            if (row.ContainsKey("FechaCreacion") &&
                row["FechaCreacion"] != null &&
                row["FechaCreacion"] != DBNull.Value)
            {
                propiedad.FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString());
            }

            if (row.ContainsKey("FechaActualizacion") &&
                row["FechaActualizacion"] != null &&
                row["FechaActualizacion"] != DBNull.Value)
            {
                propiedad.FechaActualizacion = DateTime.Parse(row["FechaActualizacion"].ToString());
            }

            if (row.ContainsKey("UsuarioCreacionId") &&
                row["UsuarioCreacionId"] != null &&
                row["UsuarioCreacionId"] != DBNull.Value)
            {
                propiedad.UsuarioCreacionId = int.Parse(row["UsuarioCreacionId"].ToString());
            }

            if (row.ContainsKey("UsuarioActualizaId") &&
                row["UsuarioActualizaId"] != null &&
                row["UsuarioActualizaId"] != DBNull.Value)
            {
                propiedad.UsuarioActualizaId = int.Parse(row["UsuarioActualizaId"].ToString());
            }

            return propiedad;
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
            var propiedad = (Propiedad)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_PROPIEDAD"
            };

            operation.AddIntParam("IdSolicitud", propiedad.IdSolicitud);
            operation.AddDecimalParam("AreaHectareas", propiedad.AreaHectareas);
            operation.AddVarcharParam("VegetacionClave", propiedad.VegetacionClave);
            operation.AddVarcharParam("PendienteClave", propiedad.PendienteClave);
            operation.AddIntParam("Active", propiedad.Active ? 1 : 0);

            if (propiedad.UsuarioCreacionId.HasValue)
            {
                operation.AddIntParam("UsuarioCreacionId", propiedad.UsuarioCreacionId.Value);
            }

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PROPIEDAD_BY_ID"
            };

            operation.AddIntParam("Id", pId);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_ALL_PROPIEDADES"
            };

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            var propiedad = (Propiedad)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_UPDATE_PROPIEDAD"
            };

            operation.AddIntParam("Id", propiedad.Id);
            operation.AddIntParam("IdSolicitud", propiedad.IdSolicitud);
            operation.AddDecimalParam("AreaHectareas", propiedad.AreaHectareas);
            operation.AddVarcharParam("VegetacionClave", propiedad.VegetacionClave);
            operation.AddVarcharParam("PendienteClave", propiedad.PendienteClave);
            operation.AddIntParam("Active", propiedad.Active ? 1 : 0);

            if (propiedad.ValorCalculado.HasValue)
            {
                operation.AddDecimalParam("ValorCalculado", propiedad.ValorCalculado.Value);
            }

            if (propiedad.UsuarioActualizaId.HasValue)
            {
                operation.AddIntParam("UsuarioActualizaId", propiedad.UsuarioActualizaId.Value);
            }

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            var propiedad = (Propiedad)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_DELETE_PROPIEDAD"
            };

            operation.AddIntParam("Id", propiedad.Id);

            return operation;
        }

        public SqlOperation GetCreateStatementWithReturnId(BaseClass dto)
        {
            var propiedad = (Propiedad)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_PROPIEDAD_RETURN_ID"
            };

            operation.AddIntParam("IdSolicitud", propiedad.IdSolicitud);
            operation.AddDecimalParam("AreaHectareas", propiedad.AreaHectareas);
            operation.AddVarcharParam("VegetacionClave", propiedad.VegetacionClave);
            operation.AddVarcharParam("PendienteClave", propiedad.PendienteClave);
            operation.AddIntParam("Active", propiedad.Active ? 1 : 0);

            if (propiedad.UsuarioCreacionId.HasValue)
            {
                operation.AddIntParam("UsuarioCreacionId", propiedad.UsuarioCreacionId.Value);
            }

            return operation;
        }
    }
}