using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
	public abstract class Tipo
	{
		protected int id;
		protected string nome;
		protected string descricao;


		public Tipo() { }

		protected Tipo(string descricao, string nome)
		{
			this.descricao = descricao;
			this.nome = nome;
		}


		public int getId()
		{
			return id;
		}

		public void setId(int id)
		{
			this.id = id;
		}

		public string getDescricao()
		{
			return descricao;
		}
		public void setDescricao(string descricao)
		{
			this.descricao = descricao;
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