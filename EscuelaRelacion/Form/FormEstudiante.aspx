<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormEstudiante.aspx.cs" Inherits="EscuelaRelacion.Form.FormEstudiante" %>

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
                <asp:TextBox ID="txtApellidoPaterno" runat="server" PlaceHolder ="Apellido Paterno"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtApellidoMaterno" runat="server" PlaceHolder ="Apellido Materno"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtEdad" runat="server" PlaceHolder ="Edad"></asp:TextBox>
                <br />
                <asp:Button ID="btnIngresarEstudiante" runat="server" Text="Ingresar Estudiante" OnClick="btnIngresarEstudiante_Click" />
                <br />
                <br />
                <asp:GridView ID="gvTablaEstudiante" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvTablaEstudiante_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                        <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    </Columns>
                </asp:GridView>
            </div>
        </center>
    </form>
</body>
</html>
