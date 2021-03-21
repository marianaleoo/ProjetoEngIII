using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Estado
    {
		private string descricao;

		public Estado() { }
		public Estado(string descricao)
		{
			this.descricao = descricao;
		}
		public string getDescricao()
		{
			return descricao;
		}
		public void setDescricao(string descricao)
		{
			this.descricao = descricao;
		}
	}
}