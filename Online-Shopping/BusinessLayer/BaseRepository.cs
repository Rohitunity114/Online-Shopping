using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BaseRepository
    {
        protected SqlConnection con;

        public BaseRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        }

        public SqlCommand GetCommand(string commandName)
        {
            SqlCommand cmd = new SqlCommand(commandName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            return cmd;
        }

    }
}
