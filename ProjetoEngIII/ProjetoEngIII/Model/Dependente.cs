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

        public Dependente()
        {

        }

        public Dependente(string nome)
        {

        }

        public Pessoa GetPessoa()
        {
            return pessoa;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;
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
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_dependente(id_cli, nome");
                strSQL.Append("VALUES (@id_cli, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@id_cli", cliente.getId());
                objComando.Parameters.AddWithValue("@nome", cliente.GetDependente());

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