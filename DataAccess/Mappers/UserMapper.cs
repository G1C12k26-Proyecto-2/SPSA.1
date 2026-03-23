using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mappers
{
    public class UserMapper : IObjectMapper, ICrudStatements, IUserStatements
    {

        public User BuildSingleObject(List<Dictionary<string, object>> rows)
        {
            if (rows.Count == 0)
                return null;

            return (User)BuildObject(rows[0]);
        }
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var user = new User();

            user.Id = int.Parse(row["Id"].ToString());
            user.Active = bool.Parse(row["Active"].ToString());
            user.UserName = row["UserName"].ToString();
            user.PasswordHash = row["PasswordHash"].ToString();
            user.FullName = row["FullName"].ToString();

            return user;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var item in rows)
            {
                results.Add(BuildObject(item));
            }
            return results;
        }

        public SqlOperation GetRetrieveByUsernameStatement(string username)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_USER_BY_USERNAME"
            };

            operation.AddVarcharParam("UserName", username);

            return operation;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var user = (User)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_USER"
            };

            operation.AddVarcharParam("UserName", user.UserName);
            operation.AddVarcharParam("PasswordHash", user.PasswordHash);
            operation.AddVarcharParam("FullName", user.FullName);
            operation.AddIntParam("Active", user.Active ? 1 : 0);

            return operation;
        }

        // CRUD not implemented yet        
        public SqlOperation GetUpdateStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetDeleteStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetRetrieveAllStatement() => throw new NotImplementedException();
        public SqlOperation GetRetrieveByIdStatement(int pId) => throw new NotImplementedException();
    }
}
