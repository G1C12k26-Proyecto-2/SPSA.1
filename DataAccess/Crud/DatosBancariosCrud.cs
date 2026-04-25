using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class DatosBancariosCrud : CrudFactory
    {
        private readonly DatosBancariosMapper _mapper;

        public DatosBancariosCrud()
        {
            _mapper = new DatosBancariosMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetInsertStatement((DatosBancariosDTO)dto));

        public override void Update(BaseClass dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetUpdateStatement((DatosBancariosDTO)dto));

        public override void Delete(BaseClass dto) => throw new NotImplementedException();
        public override List<T> RetrieveAll<T>() => throw new NotImplementedException();
        public override List<T> RetrieveById<T>(int pId) => throw new NotImplementedException();

        public DatosBancariosDTO? GetByUsuario(int usuarioId)
        {
            var rows = _sqlDao.ExecuteProcedureWithQuery(_mapper.GetByUsuarioStatement(usuarioId));
            return rows.Count > 0 ? _mapper.Map(rows[0]) : null;
        }

        public void Insert(DatosBancariosDTO dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetInsertStatement(dto));

        public void Update(DatosBancariosDTO dto)
            => _sqlDao.ExecuteProcedure(_mapper.GetUpdateStatement(dto));
    }
}
