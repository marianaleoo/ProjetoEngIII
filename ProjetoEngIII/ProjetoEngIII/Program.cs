using ProjetoEngIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Cliente cliente = new Cliente("Mariana");
            cliente.Salvar();
        }
    }
}