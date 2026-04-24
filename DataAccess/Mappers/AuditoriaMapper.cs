using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class AuditoriaMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var auditoria = new AuditoriaDTO();
            auditoria.Id = Convert.ToInt32(row["IdAuditoria"]);
            auditoria.Accion = row["Accion"] == DBNull.Value ? null : row["Accion"].ToString();
            auditoria.Descripcion = row["Descripcion"] == DBNull.Value ? null : row["Descripcion"].ToString();
            auditoria.FechaCambio = row["FechaCambio"] == DBNull.Value ? null : Convert.ToDateTime(row["FechaCambio"]);
            auditoria.Modulo = row["Modulo"] == DBNull.Value ? null : row["Modulo"].ToString();
            auditoria.Entidad = row["Entidad"] == DBNull.Value ? null : row["Entidad"].ToString();
            auditoria.EntidadId = row["EntidadId"] == DBNull.Value ? null : Convert.ToInt32(row["EntidadId"]);
            auditoria.IdSolicitud = row["IdSolicitud"] == DBNull.Value ? null : Convert.ToInt32(row["IdSolicitud"]);
            auditoria.IdUsuario = row["IdUsuario"] == DBNull.Value ? null : Convert.ToInt32(row["IdUsuario"]);
            auditoria.UsuarioNombre = row["UsuarioNombre"] == DBNull.Value ? null : row["UsuarioNombre"].ToString();
            auditoria.Usuario = row["Usuario"] == DBNull.Value ? null : row["Usuario"].ToString();
            auditoria.EstadoNuevo = row["EstadoNuevo"] == DBNull.Value ? null : row["EstadoNuevo"].ToString();
            auditoria.EstadoNuevoNombre = row["EstadoNuevoNombre"] == DBNull.Value ? null : row["EstadoNuevoNombre"].ToString();
            auditoria.EstadoAnterior = row["EstadoAnterior"] == DBNull.Value ? null : row["EstadoAnterior"].ToString();
            auditoria.EstadoAnteriorNombre = row["EstadoAnteriorNombre"] == DBNull.Value ? null : row["EstadoAnteriorNombre"].ToString();
            auditoria.Motivo = row["Motivo"] == DBNull.Value ? null : row["Motivo"].ToString();
            return auditoria;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_HISTORIAL_SOLICITUD";
            operation.AddIntParam("IdSolicitud", 0);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_HISTORIAL_SOLICITUD";
            operation.AddIntParam("IdSolicitud", pId);
            return operation;
        }
    }
}