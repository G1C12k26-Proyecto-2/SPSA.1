using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Crud
{
    public class PasswordResetTokenCrudFactory : CrudFactory
    {
        public PasswordResetTokenCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var token = dto as PasswordResetToken;

            var sqlOperation = new SqlOperation()
            {
                ProcedureName = "sp_CreatePasswordResetToken"
            };

            sqlOperation.AddIntParam("UserId", token.UserId);
            sqlOperation.AddVarcharParam("TokenHash", token.TokenHash);
            sqlOperation.AddDateTimeParam("Expiration", token.Expiration);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseClass dto)
        {
            var token = dto as PasswordResetToken;

            var sqlOperation = new SqlOperation()
            {
                ProcedureName = "sp_MarkPasswordResetTokenAsUsed"
            };

            sqlOperation.AddIntParam("Id", token.Id);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseClass dto)
        {
            // Optional: if you implement delete SP later
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            // Not really needed for this entity
            throw new NotImplementedException();
        }

        public override List<T> RetrieveById<T>(int id)
        {
            // Not used either
            throw new NotImplementedException();
        }

        // 🔍 Custom method (important one)
        public PasswordResetToken RetrieveByHash(string tokenHash)
        {
            var sqlOperation = new SqlOperation()
            {
                ProcedureName = "sp_GetValidPasswordResetToken"
            };

            sqlOperation.AddVarcharParam("TokenHash", tokenHash);

            var result = _sqlDao.ExecuteProcedureWithQuery(sqlOperation);

            if (result.Count == 0)
                return null;

            return BuildObject(result[0]);
        }

        // 🧠 Mapper (row → object)
        private PasswordResetToken BuildObject(Dictionary<string, object> row)
        {
            return new PasswordResetToken
            {
                Id = Convert.ToInt32(row["Id"]),
                UserId = Convert.ToInt32(row["UserId"]),
                TokenHash = row["TokenHash"].ToString(),
                Expiration = Convert.ToDateTime(row["Expiration"]),
                Used = Convert.ToBoolean(row["Used"])
            };
        }
    }
}
