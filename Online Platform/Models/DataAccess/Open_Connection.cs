using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Platform.Models.DataAccess
{
    public static class Open_Connection
    {
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(@"Server=localhost;Database=Online Platform;Trusted_Connection=Yes;Integrated Security=SSPI;");
            }
        }
    }
}
