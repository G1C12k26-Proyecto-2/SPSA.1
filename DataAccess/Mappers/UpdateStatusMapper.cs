using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class UpdateStatusMapper
    {
        public SqlOperation GetUpdateStatusStatement(UpdateStatusDTO dto)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_UPDATE_STATUS_SOLICITUD";
            operation.AddIntParam("IdSolicitud", dto.IdSolicitud);
            operation.AddVarcharParam("NuevoEstado", dto.NuevoEstado);
            return operation;
        }
    }
}