using ProjetoEngIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEngIII.DAO
{
    public interface IDAO
    {
        public void Salvar(EntidadeDominio entidade);        
        public void Alterar(EntidadeDominio entidade);
        public void Excluir(EntidadeDominio entidade);
        public List<EntidadeDominio> Consultar(EntidadeDominio entidade);
    }
}
