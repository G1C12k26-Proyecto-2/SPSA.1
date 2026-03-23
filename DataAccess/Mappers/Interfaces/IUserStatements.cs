using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mappers.Interfaces
{
    public interface IUserStatements
    {
        SqlOperation GetRetrieveByUsernameStatement(string username);
    }
}
