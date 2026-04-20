using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class AuditoriaCrud : CrudFactory
    {
        private AuditoriaMapper _mapper;

        public AuditoriaCrud()
        {
            _mapper = new AuditoriaMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            var operation = _mapper.GetRetrieveByIdStatement(pId);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }
    }
}