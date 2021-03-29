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
	public abstract class Tipo : EntidadeDominio
	{		
		protected string nome;
		protected string descricao;
		private Conexao conn;


		public Tipo() { }

		protected Tipo(string descricao, string nome)
		{
			this.descricao = descricao;
			this.nome = nome;
		}

		public string GetDescricao()
		{
			return descricao;
		}
		public void SetDescricao(string descricao)
		{
			this.descricao = descricao;
		}
		public string GetNome()
		{
			return nome;
		}
		public void SetNome(string nome)
		{
			this.nome = nome;
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
				strSQL.Append("INSERT INTO ");
				strSQL.Append("tb_tpdocumento");				
				strSQL.Append("(nome, descricao) ");
				strSQL.Append("VALUES (@nome,@descricao)");

				objComando.CommandText = strSQL.ToString();
				objComando.Parameters.AddWithValue("@nome", nome);
				objComando.Parameters.AddWithValue("@nome", descricao);

				if (objComando.ExecuteNonQuery() < 1)
				{
					throw new Exception("Erro ao inserir registro " + nome);
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