using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEngIII.Model
{
	public abstract class Pessoa
	{
		protected int id;

		protected List<Documento> documentos;

		public Pessoa()
		{
		}

		public int getId()
		{
			return id;
		}

		public void setId(int id)
		{
			this.id = id;
		}

		public Pessoa(List<Documento> documentos)
		{
			this.documentos = documentos;
		}

		public List<Documento> getDocumentos()
		{
			return documentos;
		}

		public void setDocumentos(List<Documento> documentos)
		{
			this.documentos = documentos;
		}

		public void addDocumento(Documento documento)
		{
			if (documentos == null)
			{
				documentos = new List<Documento>();
			}
			documentos.Add(documento);
		}
	}
}