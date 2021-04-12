using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Dependente : Pessoa
    {
        private Pessoa pessoa;
        private Cliente cliente;
        private Conexao conn;
        private TipoParentesco tpParentesco;
        private String nome;

        public Dependente() { }

        public Dependente(string nome, TipoParentesco tpParentesco)
        {
            this.nome = nome;
            this.tpParentesco = tpParentesco;
        }

        public string GetNome()
        {

            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Pessoa GetPessoa()
        {
            return pessoa;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public TipoParentesco GetTpParentesco()
        {
            return tpParentesco;
        }

        public void SetTpParentesco(TipoParentesco tpParentesco)
        {
            this.tpParentesco = tpParentesco;
        }        

    }
}