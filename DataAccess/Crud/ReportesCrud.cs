using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class ReportesCrud : CrudFactory
    {
        private ReportesMapper _mapper;

        public ReportesCrud()
        {
            _mapper = new ReportesMapper();
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
            throw new NotImplementedException();
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            throw new NotImplementedException();
        }

        public List<ReportesSolicitudesDTO> GetReportesSolicitudes()
        {
            var operation = _mapper.GetReportesSolicitudesStatement();
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<ReportesSolicitudesDTO>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildSolicitudObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((ReportesSolicitudesDTO)item);
                }
            }
            return resultList;
        }
    }
}