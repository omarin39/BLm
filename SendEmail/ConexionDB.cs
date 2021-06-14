using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SendEmailCV
{
    public class ConexionDB
    {
        public SqlConnection ConexionBase()
        {
            SqlConnection cn = new(ConfigurationManager.ConnectionStrings["StConection"].ConnectionString);
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            else
            {
                cn.Open();
            }

            return cn;
        }
    }
}
