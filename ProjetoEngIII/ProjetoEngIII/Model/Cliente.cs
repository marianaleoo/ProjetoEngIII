using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Cliente : Pessoa
    {
		private TipoCliente tpCliente;
		private List<Endereco> enderecos;
		private string nome;

		public Cliente() { }

		public Cliente(List<Documento> documentos, TipoCliente tpCliente,
				List<Endereco> enderecos, string nome)
		{

			this.documentos = documentos;
			this.tpCliente = tpCliente;
			this.enderecos = enderecos;
			this.nome = nome;
		}

		public TipoCliente getTpCliente()
		{
			return tpCliente;
		}

		public void setTpCliente(TipoCliente tpCliente)
		{
			this.tpCliente = tpCliente;
		}

		public List<Endereco> getEnderecos()
		{
			return enderecos;
		}

		public void setEnderecos(List<Endereco> enderecos)
		{
			this.enderecos = enderecos;
		}

		public void addEndereco(Endereco endereco)
		{
			if (enderecos == null)
			{
				enderecos = new List<Endereco>();
			}
			enderecos.Add(endereco);
		}

		public string getNome()
		{

			return nome;
		}

		public void setNome(string nome)
		{
			this.nome = nome;
		}
	}
}