using DTO;
using System;
using System.Collections.Generic;
using System.Text;

    namespace DataAccess.Mappers.Interfaces
    {
        public interface IObjectMapper
        {
            BaseClass BuildObject(Dictionary<string, object> row);

            List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows);
        }
    }
