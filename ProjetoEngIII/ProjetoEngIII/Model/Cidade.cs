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

		public string GetDescricao()
		{
			return descricao;
		}

		public void SetDescricao(string descricao)
		{
			this.descricao = descricao;
		}

		public Estado GetEstado()
		{
			return estado;
		}

		public void SetEstado(Estado estado)
		{
			this.estado = estado;
		}
	}
}