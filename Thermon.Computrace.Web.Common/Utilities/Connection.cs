using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Common.Utilities
{
    public class ConnectionUtils
    {
        public static bool ValidateConnectionString(string connString)
        {
            try
            {
                var con = new SqlConnectionStringBuilder(connString);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    return (conn.State == ConnectionState.Open);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
