using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Cidade
    {
		private string descricao;
		private Estado estado;

		public Cidade() { }

		public Cidade(string descricao, Estado estado)
		{
			this.descricao = descricao;
			this.estado = estado;
		}

		public string getDescricao()
		{
			return descricao;
		}

		public void setDescricao(string descricao)
		{
			this.descricao = descricao;
		}

		public Estado getEstado()
		{
			return estado;
		}

		public void setEstado(Estado estado)
		{
			this.estado = estado;
		}
	}
}