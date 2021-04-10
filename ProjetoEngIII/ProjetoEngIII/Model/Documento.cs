using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ProjetoEngIII.Util;

namespace ProjetoEngIII.Model
{
    public class Documento : EntidadeDominio
    {
   
		private string codigo;
		private DateTime validade;
		private TipoDocumento tpDocumento;
		private Pessoa pessoa;

		public Documento() { }

		public Documento(string codigo, DateTime validade, TipoDocumento tpDocumento)
		{
			this.codigo = codigo;
			this.validade = validade;
			this.tpDocumento = tpDocumento;
		}

		public TipoDocumento GetTpDocumento()
		{
			return tpDocumento;
		}
		public void SetTpDocumento(TipoDocumento tpDocumento)
		{
			this.tpDocumento = tpDocumento;
		}
		public string GetCodigo()
		{
			return codigo;
		}
		public void SetCodigo(string codigo)
		{
			this.codigo = codigo;
		}
		public DateTime GetValidade()
		{
			return validade;
		}
		public void SetValidade(DateTime validade)
		{
			this.validade = validade;
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
            Conexao conn = new Conexao();
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;
            
            try
            {  
                tpDocumento.SalvarTipoDocumento();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento(cli_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@cli_id,@tpdoc_id,@codigo,@validade)");

                objComando.CommandText = strSQL.ToString();                
                objComando.Parameters.AddWithValue("@cli_id", pessoa.GetId());
                objComando.Parameters.AddWithValue("@tpdoc_id", tpDocumento.GetId());
                objComando.Parameters.AddWithValue("@codigo", codigo);
                objComando.Parameters.AddWithValue("@validade", validade);
				if (objComando.ExecuteNonQuery() < 1)
				{
					throw new Exception("Erro ao inserir registro " + codigo);
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