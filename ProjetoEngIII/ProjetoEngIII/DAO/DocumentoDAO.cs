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
    public class DocumentoDAO : IDAO<Documento>
    {
        private Conexao conn;
        private TipoDocumento tpDocumento;
        private Documento documento;
        private Pessoa pessoa;

        public void Save(Documento documento)
        {
            TipoDocumento tpDocumento = new TipoDocumento();
            Conexao conn = new Conexao();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                SalvarTipoDocumento(documento.GetTpDocumento());

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento(cli_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@cli_id,@tpdoc_id,@codigo,@validade)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@cli_id", documento.GetPessoa().GetId());
                objComando.Parameters.AddWithValue("@tpdoc_id", documento.GetTpDocumento().GetId());
                objComando.Parameters.AddWithValue("@codigo", documento.GetCodigo());
                objComando.Parameters.AddWithValue("@validade", documento.GetValidade());
                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + documento.GetCodigo());
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


        public void SalvarTipoDocumento(EntidadeDominio entidade)
        {
            TipoDocumento tpDocumento = new TipoDocumento();
            Conexao conn = new Conexao();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;

            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_tpdocumento");
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tpDocumento.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tpDocumento.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tpDocumento.GetNome());
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
