using ProjetoEngIII.Model;
using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoEngIII.DAO
{
    public class ClienteDAO : IDAO<Cliente>
    {
        private Conexao conn;
        private TipoCliente tpCliente;
        private Cliente cliente;
        private Pessoa pessoa;
        private List<Endereco> enderecos;
        private List<Dependente> dependentes; 

        public void Save(Cliente cliente)
        {
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                SalvarTipoCliente(cliente.GetTipoCliente());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_cliente(dt_cadastro, cpf, credito, nome");
                strSQL.Append("VALUES (@dt_cadastro, @cpf, @credito, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@dt_cadastro", cliente.GetDataCadastro());
                objComando.Parameters.AddWithValue("@cpf", cliente.GetCPF());
                objComando.Parameters.AddWithValue("@credito", cliente.GetCredito());
                objComando.Parameters.AddWithValue("@nome", cliente.GetNome());

                foreach (var item in cliente.GetDependente())
                {
                    item.SetPessoa(cliente);
                    SalvarDependente(item);
                }

                foreach (var item in cliente.GetEndereco())
                {
                    item.SetPessoa(cliente);

                }

                foreach (var item in cliente.getDocumentos())
                {
                    item.SetPessoa(cliente);
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

        public void SalvarDependente(Dependente dependente)
        {
            TipoParentesco tpParentesco = new TipoParentesco();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                SalvarTipoParentesco(dependente.GetTpParentesco());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_dependente(id_tpparent, nome");
                strSQL.Append("VALUES (@id_tpparent, @nome)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@id_tpparent", dependente.GetTpParentesco().GetId());
                objComando.Parameters.AddWithValue("@nome", dependente.GetNome());

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

        //public void SalvarDocumento(Documento documento)
        //{
        //    TipoDocumento tpDocumento = new TipoDocumento();
        //    Conexao conn = new Conexao();
        //    var teste = conn.Connection();
        //    var objConn = new SqlConnection(teste);
        //    objConn.Open();
        //    var objComando = new SqlCommand();
        //    objComando.Connection = objConn;

        //    try
        //    {
        //        SalvarTipoDocumento(documento.GetTpDocumento());

        //        StringBuilder strSQL = new StringBuilder();

        //        strSQL.Append("INSERT INTO tb_documento(cli_id, tpdoc_id, codigo, ");
        //        strSQL.Append("validade) VALUES (@cli_id,@tpdoc_id,@codigo,@validade)");

        //        objComando.CommandText = strSQL.ToString();
        //        objComando.Parameters.AddWithValue("@cli_id", documento.GetPessoa().GetId());
        //        objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
        //        objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
        //        objComando.Parameters.AddWithValue("@validade", documento.GetValidade());
        //        if (objComando.ExecuteNonQuery() < 1)
        //        {
        //            throw new Exception("Erro ao inserir registro " + documento.GetCodigo());
        //        }
        //        objConn.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //        {
        //            objConn.Close();
        //        }

        //        throw new Exception("Erro ao inserir registro " + ex.Message);
        //    }
        //}

        //public void SalvarEndereco(Endereco endereco)
        //{
        //    TipoEndereco tpEndereco = new TipoEndereco();
        //    var teste = conn.Connection();
        //    var objConn = new SqlConnection(teste);
        //    objConn.Open();
        //    var objComando = new SqlCommand();
        //    objComando.Connection = objConn;

        //    try
        //    {
        //        SalvarTipoEndereco(endereco.GetTpEndereco());

        //        StringBuilder strSQL = new StringBuilder();

        //        strSQL.Append("INSERT INTO tb_endereco(cli_id, tpend_id, cidade, estado");
        //        strSQL.Append("logradouro, numero, cep) VALUES (@cli_id, @tpend_id, @cidade, @estado, @logradouro, @numero, @cep)");

        //        objComando.CommandText = strSQL.ToString();
        //        objComando.Parameters.AddWithValue("@cli_id", endereco.GetPessoa().GetId());
        //        objComando.Parameters.AddWithValue("@tpend_id", endereco.GetTpEndereco().GetId());
        //        objComando.Parameters.AddWithValue("@cidade", endereco.GetCidade().GetDescricao());
        //        objComando.Parameters.AddWithValue("@estado", endereco.GetCidade().GetEstado().getDescricao());
        //        objComando.Parameters.AddWithValue("@logradouro", endereco.GetLogradouro());
        //        objComando.Parameters.AddWithValue("@numero", endereco.GetNumero());
        //        objComando.Parameters.AddWithValue("@cep", endereco.GetCep());

        //        objConn.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //        {
        //            objConn.Close();
        //        }

        //        throw new Exception("Erro ao inserir registro " + ex.Message);
        //    }
        //}

        public void SalvarTipoCliente(EntidadeDominio entidade)
        {
            TipoCliente tpCliente = new TipoCliente();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_tpcliente");
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tpCliente.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tpCliente.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tpCliente.GetNome());
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

        public void SalvarTipoParentesco(EntidadeDominio entidade)
        {
            TipoParentesco tpParentesco = new TipoParentesco();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_tpparentesco");
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tpParentesco.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tpParentesco.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tpParentesco.GetNome());
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

        //public void SalvarTipoEndereco(EntidadeDominio entidade)
        //{
        //    TipoEndereco tpEndereco = new TipoEndereco();
        //    var teste = conn.Connection();
        //    var objConn = new SqlConnection(teste);
        //    objConn.Open();
        //    var objComando = new SqlCommand();
        //    objComando.Connection = objConn;

        //    try
        //    {
        //        StringBuilder strSQL = new StringBuilder();
        //        strSQL.Append("INSERT INTO ");
        //        strSQL.Append("tb_tpendereco");
        //        strSQL.Append("(nome, descricao) ");
        //        strSQL.Append("VALUES (@nome,@descricao)");

        //        objComando.CommandText = strSQL.ToString();
        //        objComando.Parameters.AddWithValue("@nome", tpEndereco.GetNome());
        //        objComando.Parameters.AddWithValue("@descricao", tpEndereco.GetDescricao());

        //        if (objComando.ExecuteNonQuery() < 1)
        //        {
        //            throw new Exception("Erro ao inserir registro " + tpEndereco.GetNome());
        //        }
        //        objConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //        {
        //            objConn.Close();
        //        }

        //        throw new Exception("Erro ao inserir registro " + ex.Message);
        //    }
        //}

    //    public void SalvarTipoDocumento(EntidadeDominio entidade)
    //    {
    //        TipoDocumento tpDocumento = new TipoDocumento();
    //        Conexao conn = new Conexao();
    //        var teste = conn.Connection();
    //        var objConn = new SqlConnection(teste);
    //        objConn.Open();
    //        var objComando = new SqlCommand();
    //        objComando.Connection = objConn;

    //        try
    //        {
    //            StringBuilder strSQL = new StringBuilder();
    //            strSQL.Append("INSERT INTO ");
    //            strSQL.Append("tb_tpdocumento");
    //            strSQL.Append("(nome, descricao) ");
    //            strSQL.Append("VALUES (@nome,@descricao)");

    //            objComando.CommandText = strSQL.ToString();
    //            objComando.Parameters.AddWithValue("@nome", tpDocumento.GetNome());
    //            objComando.Parameters.AddWithValue("@descricao", tpDocumento.GetDescricao());

    //            if (objComando.ExecuteNonQuery() < 1)
    //            {
    //                throw new Exception("Erro ao inserir registro " + tpDocumento.GetNome());
    //            }
    //            objConn.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            if (objConn.State == ConnectionState.Open)
    //            {
    //                objConn.Close();
    //            }

    //            throw new Exception("Erro ao inserir registro " + ex.Message);
    //        }
    //    }
    }
}