using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Crud
{
    public class LocationCrud : CrudFactory
    {
        private LocationMapper _mapper;

        public LocationCrud()
        {
            _mapper = new LocationMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var operation = _mapper.GetCreateStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override void Update(BaseClass dto)
        {
            var sqlOperation = _mapper.GetUpdateStatement(dto);
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseClass dto)
        {
            var operation = _mapper.GetDeleteStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstResults = new List<T>();
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstDict = _sqlDao.ExecuteProcedureWithQuery(sqlOperation);

            if (lstDict.Count > 0)
            {
                var objs = _mapper.BuildObjects(lstDict);

                foreach (var obj in objs)
                {
                    lstResults.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return lstResults;
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
