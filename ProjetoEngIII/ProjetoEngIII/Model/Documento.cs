using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
    public class Documento
    {
		private int id;
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
	}
}