<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="ProjetoEngIII.CadastroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cadastro de Cliente"></asp:Label>
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="ID:"></asp:Label>
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="CPF:"></asp:Label>
        <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Crédito:"></asp:Label>
        <asp:TextBox ID="txtCredito" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Tipo Cliente:"></asp:Label>
        <asp:DropDownList ID="ddlTipoCliente" runat="server" Width="136px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Descrição:"></asp:Label>
        <asp:TextBox ID="txtDescricaoCli" runat="server" Height="48px" TextMode="MultiLine" Width="280px"></asp:TextBox>
        
        <p>Endereço</p>
        <asp:Label ID="Label6" runat="server" Text="Logradouro:"></asp:Label>
        <asp:TextBox ID="txtLogradouro" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Número:"></asp:Label>
        <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Cidade:"></asp:Label>
        <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Estado:"></asp:Label>
        <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="CEP:"></asp:Label>
        <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Tipo Endereço:"></asp:Label>
        <asp:DropDownList ID="ddlTipoEndereco" runat="server" Width="136px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label14" runat="server" Text="Descrição:"></asp:Label>
        <asp:TextBox ID="txtDescricaoEnd" runat="server" Height="48px" TextMode="MultiLine" Width="280px"></asp:TextBox>
    </form>
</body>
</html>
