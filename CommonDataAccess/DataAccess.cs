using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class DataAccess : CommonDataAccess
    {
        public DataAccess(string connectionString) : base(connectionString)
        {
        }
        public int NonQuery(SqlCommand command)
        {
            try
            {
                return ExecuteNonQuery(command.CommandText);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("the command txt can't be null", ex);
            }
        }
        public List<IEntitiesInterface> Query(SqlCommand command)
        {
            try
            {
                List<IEntitiesInterface> entities = new List<IEntitiesInterface>();
                DataSet ds = ExecuteQuery(command.CommandText);
                List<Report> report = new List<Report>();
                Rides rides = null;
                foreach (DataTable item2 in ds.Tables)
                {
                    if (item2.Columns.Contains("reportsid"))
                    {
                        foreach (DataRow item in item2.Rows)
                        {
                            entities.Add(new Report(item.Field<int>("reportsid"), new Rides(item.Field<int>("id"), item.Field<string>("name"), item.Field<string>("category"), item.Field<string>("status")), item.Field<string>("status"), item.Field<DateTime>("reportstime"), item.Field<string>("notes")));
                            foreach (Report item3 in entities)
                            {
                                report.Add(item3);
                            }
                        }
                    }
                    else if (item2.Columns.Contains("id"))
                    {
                        foreach (DataRow item in item2.Rows)
                        {
                            rides = new Rides(item.Field<int>("id"), item.Field<string>("name"), item.Field<string>("category"), item.Field<string>("status"));
                            rides.Reports = report.Where(c => c.Ride.Id == rides.Id).ToList();
                            entities.Add(rides);
                        }
                    }
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("command txt can't be null", ex);
            }
        }
    }
}
