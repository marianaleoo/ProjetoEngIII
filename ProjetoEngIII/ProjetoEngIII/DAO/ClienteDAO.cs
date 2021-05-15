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
    public class ClienteDAO : IDAO
    {
        public void Salvar(EntidadeDominio entidade)
        {
            Cliente cliente = (Cliente)entidade;
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
                tipoDao.Salvar(cliente.GetTipoCliente());
                

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_cliente(dt_cadastro, cpf, credito, nome, tpcli_id)");
                strSQL.Append("VALUES (@dt_cadastro, @cpf, @credito, @nome, @tpcli_id)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", cliente.GetDataCadastro());
                objComando.Parameters.AddWithValue("@cpf", cliente.GetCPF());
                objComando.Parameters.AddWithValue("@credito", cliente.GetCredito());
                objComando.Parameters.AddWithValue("@nome", cliente.GetNome());
                objComando.Parameters.AddWithValue("@tpcli_id", tipoDao.ConsultarId(cliente.GetTipoCliente()));

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

                DependenteDAO dependenteDao = new DependenteDAO();
                foreach (var item in cliente.GetDependentes())
                {
                    item.SetPessoa(cliente);
                    dependenteDao.Salvar(item);
                }

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in cliente.GetEnderecos())
                {
                    item.SetPessoa(cliente);
                    enderecoDao.Salvar(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in cliente.getDocumentos())
                {
                    item.SetPessoa(cliente);
                    documentoDao.Salvar(item);
                }  
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

        public int ConsultarId()
        {            
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
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("SELECT MAX(id) FROM ");
                strSQL.Append("tb_cliente");                

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
            Cliente cliente = (Cliente)entidade;
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
                tipoDao.Alterar(cliente.GetTipoCliente());

                ClienteDAO clienteDao = new ClienteDAO();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("UPDATE tb_cliente SET ");
                strSQL.Append("dt_cadastro = @dt_cadastro, cpf = @cpf, credito = @credito, nome = @nome ");
                strSQL.Append("WHERE id = @id");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", cliente.GetDataCadastro());
                objComando.Parameters.AddWithValue("@cpf", cliente.GetCPF());
                objComando.Parameters.AddWithValue("@credito", cliente.GetCredito());
                objComando.Parameters.AddWithValue("@nome", cliente.GetNome());

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
            Cliente cliente = (Cliente)entidade;
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
                if (!cliente.GetId().Equals(0))
                {
                    strSQL.Append("DELETE FROM tb_cliente WHERE id =@id");
                    objComando.CommandText = strSQL.ToString();
                    objComando.Parameters.AddWithValue("@id", cliente.GetId());
                }

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao excluir registro " + cliente.GetId());
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