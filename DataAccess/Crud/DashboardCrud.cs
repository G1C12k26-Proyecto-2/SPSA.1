using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class DashboardCrud : CrudFactory
    {
        private DashboardMapper _mapper;

        public DashboardCrud()
        {
            _mapper = new DashboardMapper();
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

        public override List<T> RetrieveById<T>(int pId)
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
                var obj = _mapper.BuildObject(results[0]);
                resultList.Add((T)Convert.ChangeType(obj, typeof(T)));
            }

            return resultList;
        }
    }
}