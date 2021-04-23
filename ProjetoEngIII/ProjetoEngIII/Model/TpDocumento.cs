using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TpDocumento : Tipo
    {
		public TpDocumento()
		{
		}

		public TpDocumento(string descricao, string nome) : base(descricao, nome)
		{			
		}
	}
}