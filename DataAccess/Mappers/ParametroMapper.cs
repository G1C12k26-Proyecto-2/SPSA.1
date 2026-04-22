using DataAccess.Mappers.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mappers
{
    public class ParametroMapper : IObjectMapper, ICrudStatements
    {
        public ParametroDTO BuildSingleObject(List<Dictionary<string, object>> rows)
        {
            if (rows.Count == 0)
                return null;

            return (ParametroDTO)BuildObject(rows[0]);
        }

        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var parametro = new ParametroDTO();

            parametro.Id = int.Parse(row["Id"].ToString());
            parametro.Active = Convert.ToBoolean(row["Active"]);
            parametro.Categoria = row["Categoria"].ToString();
            parametro.Clave = row["Clave"].ToString();
            parametro.Valor = row["Valor"].ToString();
            parametro.TipoDato = row["TipoDato"].ToString();
            parametro.Descripcion = row["Descripcion"].ToString();
            parametro.OrdenVisual = int.Parse(row["OrdenVisual"].ToString());
            parametro.EsEditable = Convert.ToBoolean(row["EsEditable"]);

            if (row.ContainsKey("FechaCreacion") &&
                row["FechaCreacion"] != null &&
                row["FechaCreacion"] != DBNull.Value)
            {
                parametro.FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString());
            }

            if (row.ContainsKey("FechaActualizacion") &&
                row["FechaActualizacion"] != null &&
                row["FechaActualizacion"] != DBNull.Value)
            {
                parametro.FechaActualizacion = DateTime.Parse(row["FechaActualizacion"].ToString());
            }

            if (row.ContainsKey("UsuarioCreacionId") &&
                row["UsuarioCreacionId"] != null &&
                row["UsuarioCreacionId"] != DBNull.Value)
            {
                parametro.UsuarioCreacionId = int.Parse(row["UsuarioCreacionId"].ToString());
            }

            if (row.ContainsKey("UsuarioActualizaId") &&
                row["UsuarioActualizaId"] != null &&
                row["UsuarioActualizaId"] != DBNull.Value)
            {
                parametro.UsuarioActualizaId = int.Parse(row["UsuarioActualizaId"].ToString());
            }

            return parametro;
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
            var parametro = (ParametroDTO)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_PARAMETRO"
            };

            operation.AddVarcharParam("Categoria", parametro.Categoria);
            operation.AddVarcharParam("Clave", parametro.Clave);
            operation.AddVarcharParam("Valor", parametro.Valor);
            operation.AddVarcharParam("TipoDato", parametro.TipoDato);
            operation.AddVarcharParam("Descripcion", parametro.Descripcion);
            operation.AddIntParam("OrdenVisual", parametro.OrdenVisual);
            operation.AddIntParam("EsEditable", parametro.EsEditable ? 1 : 0);
            operation.AddIntParam("Active", parametro.Active ? 1 : 0);

            if (parametro.UsuarioCreacionId.HasValue)
            {
                operation.AddIntParam("UsuarioCreacionId", parametro.UsuarioCreacionId.Value);
            }

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PARAMETRO_BY_ID"
            };

            operation.AddIntParam("Id", pId);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_ALL_PARAMETROS"
            };

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            var parametro = (ParametroDTO)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_UPDATE_PARAMETRO"
            };

            operation.AddIntParam("Id", parametro.Id);
            operation.AddVarcharParam("Valor", parametro.Valor);
            operation.AddIntParam("Active", parametro.Active ? 1 : 0);

            if (parametro.UsuarioActualizaId.HasValue)
            {
                operation.AddIntParam("UsuarioActualizaId", parametro.UsuarioActualizaId.Value);
            }

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByCategoriaStatement(string categoria)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PARAMETROS_BY_CATEGORIA"
            };

            operation.AddVarcharParam("Categoria", categoria);

            return operation;
        }

        public SqlOperation GetRetrieveByClaveStatement(string clave)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PARAMETRO_BY_CLAVE"
            };

            operation.AddVarcharParam("Clave", clave);

            return operation;
        }
    }
}
