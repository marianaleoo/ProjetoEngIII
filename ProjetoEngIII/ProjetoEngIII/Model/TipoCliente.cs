using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TipoCliente : Tipo
    {
		public TipoCliente()
		{
		}

		public TipoCliente(string descricao, string nome)
		{
			this.descricao = descricao;
			this.nome = nome;
		}
	}
}