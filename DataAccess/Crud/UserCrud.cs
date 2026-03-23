using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Crud
{
    public class UserCrud : CrudFactory
    {
        private UserMapper _mapper;

        public UserCrud()
        {
            _mapper = new UserMapper();
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

        // 🔐 Authentication-specific method
        public T RetrieveByUsername<T>(string username)
        {
            var operation = _mapper.GetRetrieveByUsernameStatement(username);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var user = _mapper.BuildSingleObject(results);

            if (user == null)
                return default;

            return (T)Convert.ChangeType(user, typeof(T));
        }        
    }
}
