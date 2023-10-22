<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProUsuarios.aspx.cs" Inherits="ProUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 256px;
        }
        .style5
        {
            width: 393px;
            text-align: center;
        }
        .style6
        {
            width: 256px;
            height: 23px;
        }
        .style7
        {
            width: 393px;
            height: 23px;
            text-align: center;
        }
        .style8
        {
            height: 23px;
            width: 291px;
            text-align: center;
        }
        .style9
        {
            width: 291px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <table style="width:100%;" bgcolor="#CCCCFF">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    Text="Usuarios"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Text="Nombre Logueo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNombreLogueo" runat="server"></asp:TextBox>
            &nbsp;</td>
            <td class="style9">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click1" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Contraserña"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Button ID="btnRefresh" runat="server" Text="Actualizar" 
                    onclick="btnRefresh_Click" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style6">
            </td>
            <td class="style7">
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" 
                    Text="Nombre Completo"></asp:Label>
&nbsp;<asp:TextBox ID="txtNombreCompleto" runat="server"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Button ID="btnAlta" runat="server" Text="Agregar" 
                    onclick="btnAlta_Click1" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                <asp:Button ID="btnBaja" runat="server" Text="Eliminar" 
                    onclick="btnBaja_Click1" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click1" Font-Bold="True" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

