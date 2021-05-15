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
        public void Salvar(EntidadeDominio entidade)
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

                ClienteDAO clienteDao = new ClienteDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_dependente(cli_id, tpparent_id, nome)");
                strSQL.Append("VALUES (@cli_id, @tpparent_id, @nome)");
              
                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@cli_id", clienteDao.ConsultarId());
                objComando.Parameters.AddWithValue("@tpparent_id", tipoDao.ConsultarId(dependente.GetTpParentesco()));
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

        public void Alterar(EntidadeDominio entidade)
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
                tipoDao.Alterar(dependente.GetTpParentesco());

                ClienteDAO clienteDao = new ClienteDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_dependente SET ");                
                strSQL.Append("nome = @nome ");
                strSQL.Append("WHERE id = @id");                

                objComando.CommandText = strSQL.ToString();                
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

        public void Excluir(EntidadeDominio entidade)
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
            StringBuilder strSQL = new StringBuilder();
            try
            {
                if (!dependente.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_dependente WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", dependente.GetId());
                }  
                
                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + dependente.GetId());
                }
                objConn.Close();
            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao excluir registro " + ex.Message);
            }
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            return null;
        }
    }
}