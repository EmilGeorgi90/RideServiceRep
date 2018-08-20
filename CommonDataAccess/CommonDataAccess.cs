using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class CommonDataAccess
    {
        private string connectionString;

        protected CommonDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        protected DataSet ExecuteQuery(string sql, out int result)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString))
                {
                    result = adapter.Fill(dataSet);
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new ConnectionException(ex.Message, ex.InnerException);
            }
        }
        protected DataSet ExecuteQuery(string sql)
        {
            DataSet dataSet = new DataSet();
            int result = 0;
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString))
                {
                    result = adapter.Fill(dataSet);
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new ConnectionException(ex.Message, ex.InnerException);
            }
        }
        protected int ExecuteNonQuery(string sql)
        {
            int result = 0;
            try
            {
                using (SqlCommand command = new SqlCommand(sql, new SqlConnection(ConnectionString)))
                {
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ConnectionException(ex.Message, ex.InnerException);
            }
            return 0;
        }
    }
}
