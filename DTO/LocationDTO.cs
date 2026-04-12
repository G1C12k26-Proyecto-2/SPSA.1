using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LocationDTO
    {
        public string FormattedAddress { get; set; } = "";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string PlaceId { get; set; } = "";
    }
}
