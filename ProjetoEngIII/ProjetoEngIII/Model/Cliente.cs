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
        private Pessoa pessoa;
        private List<Endereco> enderecos;
        private List<Dependente> dependentes;
        private string nome;
        private decimal credito;
        private string cpf;
        private Conexao conn;
        private TipoCliente tpCliente;

        public Cliente() { }

        public Cliente(List<Endereco> enderecos, List<Dependente> dependentes, TipoCliente tpCliente, string nome, decimal credito, string cpf)
        {            
            this.enderecos = enderecos;
            this.dependentes = dependentes;
            this.nome = nome;
            this.credito = credito;
            this.cpf = cpf;
            this.tpCliente = tpCliente;

        }

        public List<Endereco> GetEndereco()
        {
            return enderecos;
        }

        public void SetEndereco(List<Endereco> enderecos)
        {
            this.enderecos = enderecos;
        }

        public void AddEndereco(Endereco endereco)
        {
            if (enderecos == null)
            {
                enderecos = new List<Endereco>();
            }
            enderecos.Add(endereco);
        }

        public string GetNome()
        {

            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetCPF()
        {

            return cpf;
        }

        public void SetCPF(string cpf)
        {
            this.cpf = cpf;
        }

        public decimal GetCredito()
        {

            return credito;
        }

        public void SetCredito(decimal credito)
        {
            this.credito = credito;
        }

        public List<Dependente> GetDependente()
        {
            return dependentes;
        }

        public void AddDependente(Dependente dependente)
        {
            if (dependentes == null)
            {
                dependentes = new List<Dependente>();
            }
            dependentes.Add(dependente);
        }

        public TipoCliente GetTipoCliente()
        {
            return tpCliente;
        }

        public void SetTipoCliente(TipoCliente tpCliente)
        {
            this.tpCliente = tpCliente;
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
                tpCliente.SalvarTipoCliente();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_cliente(dt_cadastro, cpf, credito, nome");
                strSQL.Append("VALUES (@dt_cadastro, @cpf, @credito, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", pessoa.GetDataCadastro());
                objComando.Parameters.AddWithValue("@cpf", cpf);
                objComando.Parameters.AddWithValue("@credito", credito);
                objComando.Parameters.AddWithValue("@nome", nome);

                foreach (var item in dependentes)
                {
                    item.SetPessoa(this);
                    item.Salvar();
                }

                foreach (var item in enderecos)
                {
                    item.SetPessoa(this);
                    item.Salvar();
                }

                foreach (var item in documentos)
                {
                    item.SetPessoa(this);
                    item.Salvar();
                }

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

        //public bool ValidarDependente(Cliente cliente)
        //{
        //    if (cliente.dependentes.Count > 2)
        //    {
        //        return false;

        //    }
        //    else
        //    {
        //        return true;

        //    }
        //}

        public bool ValidarCPF(Documento documento)
        {
            if (documento.GetCodigo().Length > 11)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool ValidarCredito(Cliente cliente)
        {
            if(cliente.credito < 1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            

    }
}