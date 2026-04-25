using DataAccess.Dao;
using DTO;
using System.Collections.Generic;

namespace DataAccess.Mappers
{
    public class UbicacionesMapper
    {
        public SqlOperation GetResolveStatement(ResolveUbicacionRequestDTO dto)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_RESOLVE_UBICACIONES"
            };

            operation.AddVarcharParam("Provincia", dto.Provincia ?? "");
            operation.AddVarcharParam("Canton", dto.Canton ?? "");
            operation.AddVarcharParam("Distrito", dto.Distrito ?? "");

            return operation;
        }

        public UbicacionResueltaDTO BuildObject(Dictionary<string, object> row)
        {
            var result = new UbicacionResueltaDTO();

            result.IdProvincia = row["IdProvincia"] != DBNull.Value && row["IdProvincia"] != null
                ? int.Parse(row["IdProvincia"].ToString()) : (int?)null;

            result.IdCanton = row["IdCanton"] != DBNull.Value && row["IdCanton"] != null
                ? int.Parse(row["IdCanton"].ToString()) : (int?)null;

            result.IdDistrito = row["IdDistrito"] != DBNull.Value && row["IdDistrito"] != null
                ? int.Parse(row["IdDistrito"].ToString()) : (int?)null;

            return result;
        }
    }
}