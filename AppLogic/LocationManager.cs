using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class LocationManager
    {
        public void Create(LocationDTO location)
        {
            try
            {
                var crud = new LocationCrud();
                crud.Create(location);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LocationDTO> RetrieveAll()
        {
            try
            {
                var crud = new LocationCrud();
                return crud.RetrieveAll<LocationDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LocationDTO RetrieveById(int id)
        {
            try
            {
                var crud = new LocationCrud();
                var list = crud.RetrieveById<LocationDTO>(id);

                if (list == null || list.Count == 0)
                    return null;

                return list[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
