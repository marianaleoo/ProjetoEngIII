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


        public void Salvar()
        {
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                tpParentesco.SalvarTipoParentesco();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_dependente(id_tpparent, nome");
                strSQL.Append("VALUES (@id_tpparent, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@id_tpparent", tpParentesco.GetId());
                objComando.Parameters.AddWithValue("@nome", GetNome());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro");
                }
                objConn.Close();

            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
        }

    }
}