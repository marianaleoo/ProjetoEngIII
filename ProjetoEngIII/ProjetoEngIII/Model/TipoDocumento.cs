using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TipoDocumento : Tipo
    {
		public TipoDocumento()
		{
		}

		public TipoDocumento(string descricao, string nome) : base(descricao, nome)
		{			
		}
	}
}