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
	public abstract class Tipo : EntidadeDominio
	{		
		protected string nome;
		protected string descricao;
		private Conexao conn;


		public Tipo() { }

		protected Tipo(string descricao, string nome)
		{
			this.descricao = descricao;
			this.nome = nome;
		}

		public string GetDescricao()
		{
			return descricao;
		}
		public void SetDescricao(string descricao)
		{
			this.descricao = descricao;
		}
		public string GetNome()
		{
			return nome;
		}
		public void SetNome(string nome)
		{
			this.nome = nome;
		}
    }
}