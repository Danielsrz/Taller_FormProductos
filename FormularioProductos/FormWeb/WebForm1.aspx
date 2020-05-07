<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FormWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px">
            <asp:Label ID="Label1" runat="server" Text="PRODUCTOS:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
&nbsp;<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" Width="144px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Stock:"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="Agregar" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
            <br />
            <br />
            <asp:GridView ID="dgvBuscar" runat="server" Width="376px">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
