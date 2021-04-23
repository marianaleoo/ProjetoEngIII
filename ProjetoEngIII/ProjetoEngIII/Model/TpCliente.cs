using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TpCliente : Tipo
    {
		public TpCliente()
		{
		}

		public TpCliente(string descricao, string nome) : base(descricao, nome)
		{			
		}
	}
}