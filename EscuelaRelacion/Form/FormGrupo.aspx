<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormGrupo.aspx.cs" Inherits="EscuelaRelacion.Form.FormGrupo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center> 
            <div> 
                <asp:TextBox ID="txtNombre" runat="server" PlaceHolder ="Nombre"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtAula" runat="server" PlaceHolder ="Aula"></asp:TextBox>
                <br />
                <asp:Button ID="btnIngresarGrupo" runat="server" Text="Ingresar Grupo" OnClick="btnIngresarGrupo_Click" />
                <br />
                <br />
                <asp:GridView ID="gvTablaGrupo" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Aula" HeaderText="Aula" />
                    </Columns>
                </asp:GridView>
            </div>
        </center>
    </form>
</body>
</html>
