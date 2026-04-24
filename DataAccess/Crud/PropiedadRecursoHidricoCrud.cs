using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class PropiedadRecursoHidricoCrud : CrudFactory
    {
        private PropiedadRecursoHidricoMapper _mapper;

        public PropiedadRecursoHidricoCrud()
        {
            _mapper = new PropiedadRecursoHidricoMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var operation = _mapper.GetCreateStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override void Update(BaseClass dto)
        {
            var operation = _mapper.GetUpdateStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override void Delete(BaseClass dto)
        {
            var operation = _mapper.GetDeleteStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstResults = new List<T>();

            var operation = _mapper.GetRetrieveAllStatement();
            var lstDict = _sqlDao.ExecuteProcedureWithQuery(operation);

            if (lstDict.Count > 0)
            {
                var objects = _mapper.BuildObjects(lstDict);

                foreach (var obj in objects)
                {
                    lstResults.Add((T)(object)obj);
                }
            }

            return lstResults;
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            var lstResults = new List<T>();

            var operation = _mapper.GetRetrieveByIdStatement(pId);
            var lstDict = _sqlDao.ExecuteProcedureWithQuery(operation);

            if (lstDict.Count > 0)
            {
                var objects = _mapper.BuildObjects(lstDict);

                foreach (var obj in objects)
                {
                    lstResults.Add((T)(object)obj);
                }
            }

            return lstResults;
        }

        public List<T> RetrieveByPropiedadId<T>(int idPropiedad)
        {
            var lstResults = new List<T>();

            var operation = _mapper.GetRetrieveByPropiedadIdStatement(idPropiedad);
            var lstDict = _sqlDao.ExecuteProcedureWithQuery(operation);

            if (lstDict.Count > 0)
            {
                var objects = _mapper.BuildObjects(lstDict);

                foreach (var obj in objects)
                {
                    lstResults.Add((T)(object)obj);
                }
            }

            return lstResults;
        }
    }
}