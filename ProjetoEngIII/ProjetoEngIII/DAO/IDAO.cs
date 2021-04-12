using ProjetoEngIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEngIII.DAO
{
    public interface IDAO<T>
    {
        public void Save(T obj);
    }
}
