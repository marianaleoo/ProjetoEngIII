using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TipoParentesco : Tipo
    {
        public TipoParentesco()
        {
        }

        public TipoParentesco(string descricao, string nome) : base(descricao, nome)
        { 
        }
    }
}