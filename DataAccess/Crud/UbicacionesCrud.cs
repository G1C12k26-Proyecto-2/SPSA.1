using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class UbicacionesCrud
    {
        private readonly UbicacionesMapper _mapper;
        private readonly SqlDao _sqlDao;

        public UbicacionesCrud()
        {
            _mapper = new UbicacionesMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public UbicacionResueltaDTO Resolve(ResolveUbicacionRequestDTO dto)
        {
            var operation = _mapper.GetResolveStatement(dto);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            if (results.Count > 0)
                return _mapper.BuildObject(results[0]);

            return new UbicacionResueltaDTO();
        }
    }
}