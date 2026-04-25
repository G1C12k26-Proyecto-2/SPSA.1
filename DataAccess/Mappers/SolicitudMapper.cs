using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class SolicitudMapper : IObjectMapper, ICrudStatements
    {
        private T Safe<T>(Dictionary<string, object> row, string key, T fallback = default)
        {
            if (!row.ContainsKey(key) || row[key] == null || row[key] == DBNull.Value)
                return fallback;
            try { return (T)Convert.ChangeType(row[key], typeof(T)); }
            catch { return fallback; }
        }

        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            return new SolicitudDTO
            {
                IdSolicitud = Safe<int>(row, "IdSolicitud"),
                UsuarioId = Safe<int>(row, "UsuarioId"),
                NombreFinca = Safe<string>(row, "NombreFinca"),
                Propietario = Safe<string>(row, "Propietario"),
                Email = Safe<string>(row, "Email"),
                IdProvincia = row.ContainsKey("IdProvincia") && row["IdProvincia"] != DBNull.Value ? Safe<int>(row, "IdProvincia") : (int?)null,
                Provincia = Safe<string>(row, "Provincia"),
                IdCanton = row.ContainsKey("IdCanton") && row["IdCanton"] != DBNull.Value ? Safe<int>(row, "IdCanton") : (int?)null,
                Canton = Safe<string>(row, "Canton"),
                IdDistrito = row.ContainsKey("IdDistrito") && row["IdDistrito"] != DBNull.Value ? Safe<int>(row, "IdDistrito") : (int?)null,
                Distrito = Safe<string>(row, "Distrito"),
                DistritoTexto = Safe<string>(row, "DistritoTexto"),
                Estado = Safe<string>(row, "Estado"),
                FechaSolicitud = Safe<DateTime>(row, "FechaSolicitud"),
                PagoMensual = row.ContainsKey("PagoMensual") && row["PagoMensual"] != DBNull.Value ? Safe<decimal>(row, "PagoMensual") : (decimal?)null,
                HectareasOriginal = row.ContainsKey("HectareasOriginal") && row["HectareasOriginal"] != DBNull.Value ? Safe<decimal>(row, "HectareasOriginal") : (decimal?)null,
                TipoVegetacionOriginal = Safe<string>(row, "TipoVegetacionOriginal"),
                PendienteOriginal = Safe<string>(row, "PendienteOriginal"),
                TieneRiosQuebradasOriginal = row.ContainsKey("TieneRiosQuebradasOriginal") && row["TieneRiosQuebradasOriginal"] != DBNull.Value ? Safe<bool>(row, "TieneRiosQuebradasOriginal") : (bool?)null,
                CantidadNacientesOriginal = row.ContainsKey("CantidadNacientesOriginal") && row["CantidadNacientesOriginal"] != DBNull.Value ? Safe<int>(row, "CantidadNacientesOriginal") : (int?)null,
                UsoSueloOriginal = Safe<string>(row, "UsoSueloOriginal"),
                HectareasVerificadas = row.ContainsKey("HectareasVerificadas") && row["HectareasVerificadas"] != DBNull.Value ? Safe<decimal>(row, "HectareasVerificadas") : (decimal?)null,
                TipoVegetacionVerificado = Safe<string>(row, "TipoVegetacionVerificado"),
                CalificaParaPago = row.ContainsKey("CalificaParaPago") && row["CalificaParaPago"] != DBNull.Value ? Safe<bool>(row, "CalificaParaPago") : (bool?)null,
                FechaVisitaReal = row.ContainsKey("FechaVisitaReal") && row["FechaVisitaReal"] != DBNull.Value ? Safe<DateTime>(row, "FechaVisitaReal") : (DateTime?)null,
                IngenieroNombre = Safe<string>(row, "IngenieroNombre"),
                FotosUrls = row.ContainsKey("FotosUrls") && row["FotosUrls"] != DBNull.Value
                    ? System.Text.Json.JsonSerializer.Deserialize<List<string>>(Safe<string>(row, "FotosUrls")) ?? new()
                    : new(),
                DocumentosUrls = row.ContainsKey("DocumentosUrls") && row["DocumentosUrls"] != DBNull.Value
                    ? System.Text.Json.JsonSerializer.Deserialize<List<string>>(Safe<string>(row, "DocumentosUrls")) ?? new()
                    : new(),
            };
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows) results.Add(BuildObject(row));
            return results;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var s = (CreateSolicitudDTO)dto;
            var op = new SqlOperation { ProcedureName = "SP_INSERT_SOLICITUD" };
            op.AddIntParam("UsuarioId", s.UsuarioId);
            op.AddVarcharParam("NombreFinca", s.NombreFinca);
            if (s.IdProvincia.HasValue) op.AddIntParam("IdProvincia", s.IdProvincia.Value);
            if (s.IdCanton.HasValue) op.AddIntParam("IdCanton", s.IdCanton.Value);
            if (s.IdDistrito.HasValue) op.AddIntParam("IdDistrito", s.IdDistrito.Value);
            if (s.HectareasOriginal.HasValue) op.AddDecimalParam("HectareasOriginal", s.HectareasOriginal.Value);
            if (!string.IsNullOrEmpty(s.PendienteOriginal)) op.AddVarcharParam("PendienteOriginal", s.PendienteOriginal);
            if (!string.IsNullOrEmpty(s.TipoVegetacionOriginal)) op.AddVarcharParam("TipoVegetacionOriginal", s.TipoVegetacionOriginal);
            op.AddIntParam("TieneRiosQuebradasOriginal", s.TieneRiosQuebradasOriginal ? 1 : 0);
            op.AddIntParam("CantidadNacientesOriginal", s.CantidadNacientesOriginal);
            if (!string.IsNullOrEmpty(s.UsoSueloOriginal)) op.AddVarcharParam("UsoSueloOriginal", s.UsoSueloOriginal);
            op.AddVarcharParam("Estado", string.IsNullOrEmpty(s.Estado) ? "Pendiente" : s.Estado);
            if (!string.IsNullOrEmpty(s.DistritoTexto)) op.AddVarcharParam("DistritoTexto", s.DistritoTexto);
            if (!string.IsNullOrEmpty(s.FotosUrls)) op.AddVarcharParam("FotosUrls", s.FotosUrls);
            if (!string.IsNullOrEmpty(s.DocumentosUrls)) op.AddVarcharParam("DocumentosUrls", s.DocumentosUrls);
            return op;
        }

        public SqlOperation GetRetrieveAllStatement() =>
            new SqlOperation { ProcedureName = "SP_GET_ALL_SOLICITUDES" };

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var op = new SqlOperation { ProcedureName = "SP_GET_SOLICITUD_BY_ID" };
            op.AddIntParam("IdSolicitud", pId);
            return op;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            var s = (UpdateSolicitudDTO)dto;
            var op = new SqlOperation { ProcedureName = "SP_UPDATE_SOLICITUD" };
            op.AddIntParam("IdSolicitud", s.IdSolicitud);
            op.AddVarcharParam("NombreFinca", s.NombreFinca);
            if (s.IdProvincia.HasValue) op.AddIntParam("IdProvincia", s.IdProvincia.Value);
            if (s.IdCanton.HasValue) op.AddIntParam("IdCanton", s.IdCanton.Value);
            if (s.IdDistrito.HasValue) op.AddIntParam("IdDistrito", s.IdDistrito.Value);
            return op;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            var s = (SolicitudDTO)dto;
            var op = new SqlOperation { ProcedureName = "SP_DELETE_SOLICITUD" };
            op.AddIntParam("IdSolicitud", s.IdSolicitud);
            return op;
        }

        public SqlOperation GetUpsertDetalleStatement(int idSolicitud, CreateSolicitudDTO dto)
        {
            var op = new SqlOperation { ProcedureName = "SP_UPSERT_DETALLE_SOLICITUD" };
            op.AddIntParam("IdSolicitud", idSolicitud);
            op.AddIntParam("IdDueno", dto.UsuarioId);
            if (dto.HectareasOriginal.HasValue)
                op.AddDecimalParam("HectareasOriginal", dto.HectareasOriginal.Value);
            if (!string.IsNullOrEmpty(dto.PendienteOriginal))
                op.AddVarcharParam("PendienteOriginal", dto.PendienteOriginal);
            if (!string.IsNullOrEmpty(dto.TipoVegetacionOriginal))
                op.AddVarcharParam("TipoVegetacionOriginal", dto.TipoVegetacionOriginal);
            op.AddIntParam("TieneRiosQuebradasOriginal", dto.TieneRiosQuebradasOriginal ? 1 : 0);
            op.AddIntParam("CantidadNacientesOriginal", dto.CantidadNacientesOriginal);
            if (!string.IsNullOrEmpty(dto.UsoSueloOriginal))
                op.AddVarcharParam("UsoSueloOriginal", dto.UsoSueloOriginal);
            return op;
        }

        public SqlOperation GetUpsertDetalleUpdateStatement(int idSolicitud, UpdateSolicitudDTO dto)
        {
            var op = new SqlOperation { ProcedureName = "SP_UPSERT_DETALLE_SOLICITUD" };
            op.AddIntParam("IdSolicitud", idSolicitud);
            if (dto.HectareasOriginal.HasValue)
                op.AddDecimalParam("HectareasOriginal", dto.HectareasOriginal.Value);
            if (!string.IsNullOrEmpty(dto.PendienteOriginal))
                op.AddVarcharParam("PendienteOriginal", dto.PendienteOriginal);
            if (!string.IsNullOrEmpty(dto.TipoVegetacionOriginal))
                op.AddVarcharParam("TipoVegetacionOriginal", dto.TipoVegetacionOriginal);
            if (dto.TieneRiosQuebradasOriginal.HasValue)
                op.AddIntParam("TieneRiosQuebradasOriginal", dto.TieneRiosQuebradasOriginal.Value ? 1 : 0);
            if (dto.CantidadNacientesOriginal.HasValue)
                op.AddIntParam("CantidadNacientesOriginal", dto.CantidadNacientesOriginal.Value);
            if (!string.IsNullOrEmpty(dto.UsoSueloOriginal))
                op.AddVarcharParam("UsoSueloOriginal", dto.UsoSueloOriginal);
            return op;
        }
    }
}