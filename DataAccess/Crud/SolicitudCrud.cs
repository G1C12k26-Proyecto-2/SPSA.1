using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class SolicitudCrud : CrudFactory
    {
        private readonly SolicitudMapper _mapper;

        public SolicitudCrud()
        {
            _mapper = new SolicitudMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetCreateStatement(dto));

        public override void Update(BaseClass dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetUpdateStatement(dto));

        public override void Delete(BaseClass dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetDeleteStatement(dto));

        public override List<T> RetrieveAll<T>()
        {
            var results = new List<T>();
            var rows = _sqlDao.ExecuteProcedureWithQuery(_mapper.GetRetrieveAllStatement());
            foreach (var obj in _mapper.BuildObjects(rows))
                results.Add((T)Convert.ChangeType(obj, typeof(T)));
            return results;
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            var results = new List<T>();
            var rows = _sqlDao.ExecuteProcedureWithQuery(_mapper.GetRetrieveByIdStatement(pId));
            foreach (var obj in _mapper.BuildObjects(rows))
                results.Add((T)Convert.ChangeType(obj, typeof(T)));
            return results;
        }

        public List<T> RetrieveByUsuario<T>(int usuarioId)
        {
            var op = new SqlOperation { ProcedureName = "SP_GET_SOLICITUDES" };
            op.AddIntParam("UsuarioId", usuarioId);
            var results = new List<T>();
            var rows = _sqlDao.ExecuteProcedureWithQuery(op);
            foreach (var obj in _mapper.BuildObjects(rows))
                results.Add((T)Convert.ChangeType(obj, typeof(T)));
            return results;
        }

        public int CreateAndReturnId(CreateSolicitudDTO dto)
        {
            var op = _mapper.GetCreateStatement(dto);
            var rows = _sqlDao.ExecuteProcedureWithQuery(op);
            if (rows.Count > 0 && rows[0].ContainsKey("IdSolicitud"))
                return Convert.ToInt32(rows[0]["IdSolicitud"]);
            return 0;
        }

        public void UpsertDetalle(int idSolicitud, CreateSolicitudDTO dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetUpsertDetalleStatement(idSolicitud, dto));

        public void UpsertDetalleUpdate(int idSolicitud, UpdateSolicitudDTO dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetUpsertDetalleUpdateStatement(idSolicitud, dto));
    }
}