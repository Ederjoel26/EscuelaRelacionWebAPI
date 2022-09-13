<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormEstudianteGrupo.aspx.cs" Inherits="EscuelaRelacion.Form.FormEstudianteGrupo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <div>
                        <asp:DropDownList ID="ddlGrupos" runat="server"></asp:DropDownList>
                        <br />
                        <asp:GridView ID="gvTablaEstudiante" runat="server" AutoGenerateColumns="False" Height="149px">

                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbEstudiantes" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnRelacionar" runat="server" Text="Agregar alumnos al grupo" OnClick="btnRelacionar_Click" />
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
