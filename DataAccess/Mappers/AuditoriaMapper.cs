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
            auditoria.UsuarioId = Convert.ToInt32(row["UsuarioId"]);
            auditoria.UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString();
            auditoria.FullName = row["FullName"] == DBNull.Value ? null : row["FullName"].ToString();
            auditoria.Modulo = row["Modulo"].ToString();
            auditoria.Accion = row["Accion"].ToString();
            auditoria.Descripcion = row["Descripcion"] == DBNull.Value ? null : row["Descripcion"].ToString();
            auditoria.IpAddress = row["IpAddress"] == DBNull.Value ? null : row["IpAddress"].ToString();
            auditoria.FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]);
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
            operation.ProcedureName = "SP_Auditoria_GetAll";
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Auditoria_GetById";
            operation.AddIntParam("IdAuditoria", pId);
            return operation;
        }
    }
}