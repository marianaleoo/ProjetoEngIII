using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class TpParentesco : Tipo
    {
        public TpParentesco()
        {
        }

        public TpParentesco(string descricao, string nome) : base(descricao, nome)
        { 
        }
    }
}