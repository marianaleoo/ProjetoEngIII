using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class EntidadeDominio
    {
      

        public int id;

        public DateTime dataCadastro;
            
        public int GetId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public DateTime GetDataCadastro()
        {
            return dataCadastro = DateTime.Now;
        }

        public void SetDataCadastro(DateTime dataCadastro)
        {
            this.dataCadastro = dataCadastro;
        }
    }

    
}