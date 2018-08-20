using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;
using System.Data.SqlClient;

namespace business
{
    public static class Business
    {
        public static List<Rides> GetData(SqlCommand command)
        {
            List<Rides> rides = new List<Rides>();
            DataAccess.DataAccess dataAccess = new DataAccess.DataAccess(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RideService;Integrated Security=True");
            List<IEntitiesInterface> entites = dataAccess.Query(command);
            foreach (Rides item in entites)
            {
                rides.Add(item);
            }
            return rides;
        }
        public static int NonQuery(SqlCommand command)
        {
            DataAccess.DataAccess dataAccess = new DataAccess.DataAccess(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RideService;Integrated Security=True");
            return dataAccess.NonQuery(command);
        }
    }
}
