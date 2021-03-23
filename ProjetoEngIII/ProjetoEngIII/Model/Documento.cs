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
    public class Documento
    {
		private int id;
		private string codigo;
		private DateTime validade;
		private TipoDocumento tpDocumento;
		private Pessoa pessoa;
		private Conexao conn;

		public Documento() { }

		public Documento(string codigo, DateTime validade, TipoDocumento tpDocumento)
		{
			this.codigo = codigo;
			this.validade = validade;
			this.tpDocumento = tpDocumento;
		}

		public TipoDocumento getTpDocumento()
		{
			return tpDocumento;
		}
		public void setTpDocumento(TipoDocumento tpDocumento)
		{
			this.tpDocumento = tpDocumento;
		}
		public string getCodigo()
		{
			return codigo;
		}
		public void setCodigo(string codigo)
		{
			this.codigo = codigo;
		}
		public DateTime getValidade()
		{
			return validade;
		}
		public void setValidade(DateTime validade)
		{
			this.validade = validade;
		}
		public Pessoa getPessoa()
		{
			return pessoa;
		}

		public void setPessoa(Pessoa pessoa)
		{
			this.pessoa = pessoa;
		}

        public void salvar()
        {
            var teste = conn.Connection();
            var objConn = new SqlConnection(teste);
            objConn.Open();
            var objComando = new SqlCommand();
            objComando.Connection = objConn;
            
            try
            {  
                tpDocumento.salvar();

                StringBuilder strSQL = new StringBuilder();

                strSQL.Append("INSERT INTO tb_documento(cli_id, tpdoc_id, codigo, ");
                strSQL.Append("validade) VALUES (@cli_id,@tpdoc_id,@codigo,@validade)");

                objComando.CommandText = strSQL.ToString();                
                objComando.Parameters.AddWithValue("@cli_id", pessoa.getId());
                objComando.Parameters.AddWithValue("@tpdoc_id", tpDocumento.getId());
                objComando.Parameters.AddWithValue("@tpdoc_id", codigo);
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