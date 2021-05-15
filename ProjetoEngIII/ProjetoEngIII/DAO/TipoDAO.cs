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
    public class TipoDAO : IDAO
    {
        public void Salvar(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
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
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tipo.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tipo.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tipo.GetNome());
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

        public int ConsultarId(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
            int id = 0;
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
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT MAX(id) FROM ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);

                objComando.CommandText = strSQL.ToString();

                id = Convert.ToInt32(objComando.ExecuteScalar());

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
            return id;
        }

        public void Alterar(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
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
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("UPDATE ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                strSQL.Append(" SET ");
                strSQL.Append("nome = @nome, descricao = @descricao ");
                strSQL.Append("WHERE id = @id");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tipo.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tipo.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tipo.GetNome());
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
            Tipo tipo = (Tipo)entidade;
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
                if (!tipo.GetId().Equals(0))
                {
                    var nmClass = entidade.GetType().Name.ToLower();
                    strSQL.Append("DELETE FROM ");
                    strSQL.Append("tb_");
                    strSQL.Append(nmClass);                    
                    strSQL.Append("WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", tipo.GetId());
                }
                
                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + tipo.GetId());
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
            Tipo tipo = (Tipo)entidade;
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
            List<Tipo> list;
            try
            {
                if (!tipo.GetId().Equals(0))
                {
                    var nmClass = entidade.GetType().Name.ToLower();
                    strSQL.Append("SELECT * FROM ");
                    strSQL.Append("tb_");
                    strSQL.Append(nmClass);
                    strSQL.Append("WHERE id =@id");
                    //list = strSQL.ToString().ToList();
                    //objComando.CommandText = strSQL.ToString();
                    //objComando.Parameters.AddWithValue("@id", tipo.GetId());
                }
                
                objConn.Close();
                return null;
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
    }
}