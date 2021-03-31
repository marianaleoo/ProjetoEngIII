using ProjetoEngIII.Model;
using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoEngIII
{
    public partial class Cliente : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    TipoDocumento tipoDocumentoRg = new TipoDocumento();

        //    tipoDocumentoRg.SetDescricao("REGISTRO GERAL");

        //    tipoDocumentoRg.SetNome("RG");

        //    Documento rg = new Documento("30309900/7", DateTime.Now, tipoDocumentoRg);

        //    List<Documento> documentos = new List<Documento>();
        //    documentos.Add(rg);

        //    TipoEndereco tipoEnderecoEntrega = new TipoEndereco("Endereco para entrega de pedidos", "Entrega");
        //    Estado sp = new Estado("SP");
        //    Cidade mogi = new Cidade("Mogi das Cruzes", sp);

        //    String rua = "Av 7 de setembro";
        //    String numero = "200";
        //    String cep = "08790-000";

        //    Endereco endereco = new Endereco(rua, numero, cep, null, mogi, tipoEnderecoEntrega);

        //    List<Endereco> enderecos = new List<Endereco>();
        //    enderecos.Add(endereco);

        //    TipoParentesco tipoParentesco = new TipoParentesco();

        //    tipoParentesco.SetDescricao("Filho");

        //    tipoParentesco.SetNome("João");

        //    String nome = "Joao";

        //    Dependente dependente = new Dependente(nome, tipoParentesco);

        //    List<Dependente> dependentes = new List<Dependente>();
        //    dependentes.Add(dependente);

        //    TipoCliente tipoClienteVip = new TipoCliente("Cliente que gasta bem!", "VIP");

        //    Cliente cliente = new Cliente(enderecos, dependentes, tipoClienteVip, "Joao", 100, "12312312312");

        //    cliente.Salvar();
       // }
    }
}