using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Endereco
    {
		private int id;
		private Pessoa pessoa;
		private string logradouro;
		private string numero;
		private string cep;
		private string complemento;
		private Cidade cidade;
		private TipoEndereco tpEndereco;

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



		public int getId()
		{
			return id;
		}

		public void setId(int id)
		{
			this.id = id;
		}

		public Pessoa getPessoa()
		{
			return pessoa;
		}

		public void setPessoa(Pessoa pessoa)
		{
			this.pessoa = pessoa;
		}

		public TipoEndereco getTpEndereco()
		{
			return tpEndereco;
		}

		public void setTpEndereco(TipoEndereco tpEndereco)
		{
			this.tpEndereco = tpEndereco;
		}

		public string getLogradouro()
		{
			return logradouro;
		}

		public void setLogradouro(string logradouro)
		{
			this.logradouro = logradouro;
		}

		public string getNumero()
		{
			return numero;
		}

		public void setNumero(string numero)
		{
			this.numero = numero;
		}

		public string getCep()
		{
			return cep;
		}

		public void setCep(string cep)
		{
			this.cep = cep;
		}

		public string getComplemento()
		{
			return complemento;
		}

		public void setComplemento(string complemento)
		{
			this.complemento = complemento;
		}

		public Cidade getCidade()
		{
			return cidade;
		}

		public void setCidade(Cidade cidade)
		{
			this.cidade = cidade;
		}
	}
}