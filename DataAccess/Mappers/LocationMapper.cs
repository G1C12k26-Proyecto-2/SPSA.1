using DataAccess.Mappers.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mappers
{
    public class LocationMapper : IObjectMapper, ICrudStatements
    {
        public LocationDTO BuildSingleObject(List<Dictionary<string, object>> rows)
        {
            if (rows.Count == 0)
                return null;

            return (LocationDTO)BuildObject(rows[0]);
        }

        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var location = new LocationDTO();

            location.Id = int.Parse(row["Id"].ToString());
            location.Address = row["Address"].ToString();
            location.Latitude = decimal.Parse(row["Latitude"].ToString());
            location.Longitude = decimal.Parse(row["Longitude"].ToString());

            if (row.ContainsKey("PlaceId") && row["PlaceId"] != null)
            {
                location.PlaceId = row["PlaceId"].ToString();
            }

            return location;
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

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var location = (LocationDTO)dto;

            var operation = new SqlOperation
            {
                ProcedureName = "SP_CREATE_LOCATION"
            };

            operation.AddVarcharParam("Address", location.Address);
            operation.AddDecimalParam("Latitude", location.Latitude);
            operation.AddDecimalParam("Longitude", location.Longitude);
            operation.AddVarcharParam("PlaceId", location.PlaceId);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_LOCATION_BY_ID"
            };

            operation.AddIntParam("Id", pId);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_ALL_LOCATIONS"
            };

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto) => throw new NotImplementedException();

        public SqlOperation GetDeleteStatement(BaseClass dto) => throw new NotImplementedException();
    }
}