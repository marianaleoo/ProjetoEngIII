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
        
        private List<Endereco> enderecos;
        private List<Dependente> dependentes;
        private string nome;
        private decimal credito;
        private string cpf;        
        private TpCliente tpCliente;

        public Cliente()
        {
        }

        public Cliente(List<Documento> documentos, List<Endereco> enderecos, List<Dependente> dependentes, string nome, decimal credito, string cpf, TpCliente tpCliente) : base(documentos)
        {            
            this.enderecos = enderecos;
            this.dependentes = dependentes;
            this.nome = nome;
            this.credito = credito;
            this.cpf = cpf;
            this.tpCliente = tpCliente;
        }

        public List<Endereco> GetEnderecos()
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

        public List<Dependente> GetDependentes()
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

        public TpCliente GetTipoCliente()
        {
            return tpCliente;
        }

        public void SetTipoCliente(TpCliente tpCliente)
        {
            this.tpCliente = tpCliente;
        }

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