using ProjetoEngIII.DAO;
using ProjetoEngIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoEngIII
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TpDocumento tipoDocumentoRg = new TpDocumento();

            tipoDocumentoRg.SetDescricao("REGISTRO GERAL");

            tipoDocumentoRg.SetNome("RG");

            Documento documento = new Documento("30309900/7", DateTime.Now, tipoDocumentoRg);

            List<Documento> documentos = new List<Documento>();
            documentos.Add(documento);

            TpEndereco tipoEnderecoEntrega = new TpEndereco("Endereco para entrega de pedidos", "Entrega");
            Estado sp = new Estado("SP");
            Cidade mogi = new Cidade("Mogi das Cruzes", sp);

            String rua = "Av 7 de setembro";
            String numero = "200";
            String cep = "08790-000";

            Endereco endereco = new Endereco(rua, numero, cep, null, mogi, tipoEnderecoEntrega);

            List<Endereco> enderecos = new List<Endereco>();
            enderecos.Add(endereco);

            TpParentesco tipoParentesco = new TpParentesco();

            tipoParentesco.SetDescricao("Filho");

            tipoParentesco.SetNome("João");

            String nome = "Joao";

            Dependente dependente = new Dependente(nome, tipoParentesco);

            List<Dependente> dependentes = new List<Dependente>();
            dependentes.Add(dependente);

            TpCliente tipoClienteVip = new TpCliente("Cliente que gasta bem!", "VIP");

            Cliente cliente = new Cliente(documentos, enderecos, dependentes, "mariana", 100, "12312312312", tipoClienteVip);

            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Save(cliente);

        }
    }
}