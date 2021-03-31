using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Endereco : EntidadeDominio
    {		
		private Pessoa pessoa;
		private string logradouro;
		private string numero;
		private string cep;
		private string complemento;
		private Cidade cidade;
		private TipoEndereco tpEndereco;
        private Conexao conn;

        public Endereco() { }

		public Endereco(string logradouro, string numero, string cep,
				string complemento, Cidade cidade, TipoEndereco tpEndereco)
		{
			this.logradouro = logradouro;
			this.numero = numero;
			this.cep = cep;
			this.complemento = complemento;
			this.cidade = cidade;
			this.tpEndereco = tpEndereco;
		}

		public Pessoa GetPessoa()
		{
			return pessoa;
		}

		public void SetPessoa(Pessoa pessoa)
		{
			this.pessoa = pessoa;
		}

		public TipoEndereco GetTpEndereco()
		{
			return tpEndereco;
		}

		public void SetTpEndereco(TipoEndereco tpEndereco)
		{
			this.tpEndereco = tpEndereco;
		}

		public string GetLogradouro()
		{
			return logradouro;
		}

		public void SetLogradouro(string logradouro)
		{
			this.logradouro = logradouro;
		}

		public string GetNumero()
		{
			return numero;
		}

		public void SetNumero(string numero)
		{
			this.numero = numero;
		}

		public string GetCep()
		{
			return cep;
		}

		public void SetCep(string cep)
		{
			this.cep = cep;
		}

		public string GetComplemento()
		{
			return complemento;
		}

		public void SetComplemento(string complemento)
		{
			this.complemento = complemento;
		}

		public Cidade GetCidade()
		{
			return cidade;
		}

		public void SetCidade(Cidade cidade)
		{
			this.cidade = cidade;
		}

        public void Salvar()
        {
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                tpEndereco.SalvarTipoEndereco();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_endereco(cli_id, tpend_id, cidade, estado");
                strSQL.Append("logradouro, numero, cep) VALUES (@cli_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@cli_id", pessoa.GetId());
                objComando.Parameters.AddWithValue("@tpend_id", tpEndereco.GetId());
                objComando.Parameters.AddWithValue("@cidade", cidade.GetDescricao());
                objComando.Parameters.AddWithValue("@estado", cidade.GetEstado().getDescricao());
				objComando.Parameters.AddWithValue("@logradouro", logradouro);
				objComando.Parameters.AddWithValue("@numero", numero);
				objComando.Parameters.AddWithValue("@cep", cep);

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