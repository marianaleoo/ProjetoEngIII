using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Util
{
    public class Conexao
    {
        SqlConnection objConn;
       
        string strConnBD = Convert.ToString(ConfigurationSettings.AppSettings["connectionString"].ToString());

        public void AbreConn()
        {
            objConn = new SqlConnection(strConnBD);
            objConn.Open();
        }

        public void FechaConn()
        {
            objConn.Close();
        }
    }
}