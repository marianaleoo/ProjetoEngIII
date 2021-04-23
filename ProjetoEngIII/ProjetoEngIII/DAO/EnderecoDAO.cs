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
    public class EnderecoDAO : IDAO<Endereco>
    {
        private Cidade cidade;
        private TipoEndereco tpEndereco;
        private Conexao conn;
        private Pessoa pessoa;
        public void Save(Endereco endereco)
        {
            TipoEndereco tpEndereco = new TipoEndereco();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                SalvarTipoEndereco(endereco.GetTpEndereco());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_endereco(cli_id, tpend_id, cidade, estado");
                strSQL.Append("logradouro, numero, cep) VALUES (@cli_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@cli_id", endereco.GetPessoa().GetId());
                objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
                objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
                objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
                objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
                objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
                objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

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

        public void SalvarTipoEndereco(EntidadeDominio entidade)
        {
            TipoEndereco tpEndereco = new TipoEndereco();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_tpendereco");
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tpEndereco.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tpEndereco.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tpEndereco.GetNome());
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