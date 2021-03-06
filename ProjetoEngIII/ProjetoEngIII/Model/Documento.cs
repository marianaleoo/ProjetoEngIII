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
		private TpDocumento tpDocumento;
		private Pessoa pessoa;

		public Documento() { }

		public Documento(string codigo, DateTime validade, TpDocumento tpDocumento)
		{
			this.codigo = codigo;
			this.validade = validade;
			this.tpDocumento = tpDocumento;
		}

		public TpDocumento GetTpDocumento()
		{
			return tpDocumento;
		}
		public void SetTpDocumento(TpDocumento tpDocumento)
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
    }
}