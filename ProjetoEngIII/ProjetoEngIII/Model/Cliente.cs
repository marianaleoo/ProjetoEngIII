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
    public class Cliente : Pessoa
    {
        //private TipoCliente tpCliente;
        //private List<Endereco> enderecos;
        //private List<Dependente> dependentes;
        //private Endereco endereco;
        private string nome;
        private Conexao conn;

        public Cliente() { }

        public Cliente( string nome)
        {
            this.nome = nome;

        }

        //public TipoCliente GetTpCliente()
        //{
        //    return tpCliente;
        //}

        //public void SetTpCliente(TipoCliente tpCliente)
        //{
        //    this.tpCliente = tpCliente;
        //}

        //public List<Endereco> GetEnderecos()
        //{
        //    return enderecos;
        //}

        //public void SetEnderecos(List<Endereco> enderecos)
        //{
        //    this.enderecos = enderecos;
        //}

        //public void AddEndereco(Endereco endereco)
        //{
        //    if (enderecos == null)
        //    {
        //        enderecos = new List<Endereco>();
        //    }
        //    enderecos.Add(endereco);
        //}

        public string GetNome()
        {

            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        //public List<Dependente> GetDependente()
        //{
        //    return dependentes;
        //}

        //public void AddDependente(Dependente dependente)
        //{
        //    if (dependentes == null)
        //    {
        //         dependentes = new List<Dependente>();
        //    }
        //    dependentes.Add(dependente);
        //}
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

                strSQL.Append("INSERT INTO tb_cliente(nome");
                strSQL.Append("VALUES (@nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", nome);
 

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