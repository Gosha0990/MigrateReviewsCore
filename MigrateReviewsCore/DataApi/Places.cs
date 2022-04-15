using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.Data
{
    internal class Places
    {
        //обязательное
        public string Name { get; set; }
        //необязательное
        public string ExternalPlaceId { get; set; }
        //необязательное
        public int PlaceType { get; set; }
        //необязательное
        public string[] PlaceAdministratorId { get; set; }
        //необязательное
        public string EmployeesPage { get; set; }
        //необязательное
        public string RouteId { get; set; }
        //необязательное
        public string BackgroundUrl { get; set; }
        //необязательное
        public string[] ChildPlaceIds { get; set; }
        //необязательное
        public bool IsHead { get; set; }
        //необязательное
        public string WebSite { get; set; }
        //необязательное
        public string Comment { get; set; }
        //необязательное
        public string AddressInfo { get; set; }
        //необязательное
        public string Country { get; set; }
        //необязательное
        public string City { get; set; }
        //необязательное
        public string Address { get; set; }
        //необязательное
        public int Latitude { get; set; }
        //необязательное
        public int Longitude { get; set; }
    }
}
