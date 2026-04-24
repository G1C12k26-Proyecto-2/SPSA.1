using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Crud
{
    public class ParametroCrud : CrudFactory
    {
        private ParametroMapper _mapper;

        public ParametroCrud()
        {
            _mapper = new ParametroMapper();
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
            throw new System.NotImplementedException("No se permite eliminar parámetros.");
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

        public List<T> RetrieveByCategoria<T>(string categoria)
        {
            var lstResults = new List<T>();

            var operation = _mapper.GetRetrieveByCategoriaStatement(categoria);
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

        public List<T> RetrieveByClave<T>(string clave)
        {
            var lstResults = new List<T>();

            var operation = _mapper.GetRetrieveByClaveStatement(clave);
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