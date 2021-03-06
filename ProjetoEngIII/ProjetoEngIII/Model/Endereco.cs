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
		private TpEndereco tpEndereco;
        private Conexao conn;

        public Endereco() { }

		public Endereco(string logradouro, string numero, string cep,
				string complemento, Cidade cidade, TpEndereco tpEndereco)
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

		public TpEndereco GetTpEndereco()
		{
			return tpEndereco;
		}

		public void SetTpEndereco(TpEndereco tpEndereco)
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
        
    }
}