using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class UpdateStatusCrud : CrudFactory
    {
        private UpdateStatusMapper _mapper;

        public UpdateStatusCrud()
        {
            _mapper = new UpdateStatusMapper();
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

        public void UpdateStatus(UpdateStatusDTO dto)
        {
            var operation = _mapper.GetUpdateStatusStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }
    }
}