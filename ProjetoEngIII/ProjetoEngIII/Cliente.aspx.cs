using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoEngIII
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            Conexao conn = new Conexao();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
        }
    }
}