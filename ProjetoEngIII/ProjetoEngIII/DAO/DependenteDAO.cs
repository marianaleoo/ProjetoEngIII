using ProjetoEngIII.Model;
using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoEngIII.DAO
{
    public class DependenteDAO : IDAO
    {        
        public void Save(EntidadeDominio entidade)
        {            
            Dependente dependente = (Dependente)entidade;
            #region Conexão BD
            Conexao conn = new Conexao();
            var conexao = conn.Connection();
            var objConn = new SqlConnection(conexao);
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.Open();
            }
            var objComando = new SqlCommand();
            objComando.Connection = objConn;
            #endregion

            try
            {
                TipoDAO tipoDao = new TipoDAO();
                tipoDao.Salvar(dependente.GetTpParentesco());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_dependente(tpparent_id, nome)");
                strSQL.Append("VALUES (@tpparent_id, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@tpparent_id", dependente.GetTpParentesco().GetId());
                objComando.Parameters.AddWithValue("@nome", dependente.GetNome());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
        }
    }
}