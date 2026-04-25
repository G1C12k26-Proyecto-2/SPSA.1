using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class DatosBancariosMapper
    {
        public SqlOperation GetByUsuarioStatement(int usuarioId)
        {
            var op = new SqlOperation { ProcedureName = "SP_GET_DATOS_BANCARIOS_BY_USUARIO" };
            op.AddIntParam("UsuarioId", usuarioId);
            return op;
        }

        public SqlOperation GetInsertStatement(DatosBancariosDTO dto)
        {
            var op = new SqlOperation { ProcedureName = "SP_INSERT_DATOS_BANCARIOS" };
            op.AddIntParam("UsuarioId", dto.UsuarioId);
            op.AddVarcharParam("NombreTitular", dto.NombreTitular);
            op.AddVarcharParam("CedulaTitular", dto.CedulaTitular);
            op.AddVarcharParam("Banco", dto.Banco);
            op.AddVarcharParam("TipoCuenta", dto.TipoCuenta);
            op.AddVarcharParam("NumeroCuenta", dto.NumeroCuenta);
            return op;
        }

        public SqlOperation GetUpdateStatement(DatosBancariosDTO dto)
        {
            var op = new SqlOperation { ProcedureName = "SP_UPDATE_DATOS_BANCARIOS" };
            op.AddIntParam("UsuarioId", dto.UsuarioId);
            op.AddVarcharParam("NombreTitular", dto.NombreTitular);
            op.AddVarcharParam("CedulaTitular", dto.CedulaTitular);
            op.AddVarcharParam("Banco", dto.Banco);
            op.AddVarcharParam("TipoCuenta", dto.TipoCuenta);
            op.AddVarcharParam("NumeroCuenta", dto.NumeroCuenta);
            return op;
        }

        public DatosBancariosDTO Map(Dictionary<string, object> row)
        {
            return new DatosBancariosDTO
            {
                Id = Convert.ToInt32(row["IdDatosBancarios"]),
                UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                NombreTitular = row["NombreTitular"]?.ToString() ?? "",
                CedulaTitular = row["CedulaTitular"]?.ToString() ?? "",
                Banco = row["Banco"]?.ToString() ?? "",
                TipoCuenta = row["TipoCuenta"]?.ToString() ?? "",
                NumeroCuenta = row["NumeroCuenta"]?.ToString() ?? "",
                FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                FechaActualizacion = row["FechaActualizacion"] == DBNull.Value ? null : Convert.ToDateTime(row["FechaActualizacion"])
            };
        }
    }
}
