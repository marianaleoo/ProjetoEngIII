using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TipoEndereco : Tipo
    {
		public TipoEndereco()
		{
		}

		public TipoEndereco(string descricao, string nome) : base (descricao, nome)
		{			
		}

	}
}