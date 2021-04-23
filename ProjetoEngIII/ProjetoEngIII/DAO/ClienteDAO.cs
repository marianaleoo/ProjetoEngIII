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
        public void Save(EntidadeDominio entidade)
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

                strSQL.Append("INSERT INTO tb_cliente(dt_cadastro, cpf, credito, nome)");
                strSQL.Append("VALUES (@dt_cadastro, @cpf, @credito, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", cliente.GetDataCadastro());
                objComando.Parameters.AddWithValue("@cpf", cliente.GetCPF());
                objComando.Parameters.AddWithValue("@credito", cliente.GetCredito());
                objComando.Parameters.AddWithValue("@nome", cliente.GetNome());

                DependenteDAO dependenteDao = new DependenteDAO();
                foreach (var item in cliente.GetDependentes())
                {
                    item.SetPessoa(cliente);
                    dependenteDao.Save(item);
                }

                EnderecoDAO enderecoDao = new EnderecoDAO();
                foreach (var item in cliente.GetEnderecos())
                {
                    item.SetPessoa(cliente);
                    enderecoDao.Save(item);
                }

                DocumentoDAO documentoDao = new DocumentoDAO();
                foreach (var item in cliente.getDocumentos())
                {
                    item.SetPessoa(cliente);
                    documentoDao.Save(item);
                }

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