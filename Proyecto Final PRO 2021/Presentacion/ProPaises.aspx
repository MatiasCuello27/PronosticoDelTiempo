<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProPaises.aspx.cs" Inherits="ProPaises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 248px;
        }
        .style5
        {
            width: 319px;
            text-align: center;
        }
        .style6
        {
            width: 373px;
            text-align: center;
        }
        .style7
        {
            width: 443px;
            height: 30px;
            text-align: center;
        }
        .style8
        {
            width: 248px;
            height: 30px;
        }
        .style9
        {
            width: 373px;
            text-align: center;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    Text="Paises"></asp:Label>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Codigo Pais"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodigoPais" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nombre Pais"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNombrePais" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                <asp:Button ID="btnAlta" runat="server" Text="Agregar" 
                    onclick="btnAlta_Click1" Font-Bold="True" />
            </td>
            <td class="style6">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style7">
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                <asp:Button ID="btnBaja" runat="server" Text="Eliminar" 
                    onclick="btnBaja_Click1" Font-Bold="True" />
            </td>
            <td class="style6">
                <asp:Button ID="btnLimpiar" runat="server" Text="Refresh" 
                    onclick="btnLimpiar_Click1" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style7">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click1" Font-Bold="True" />
            </td>
            <td class="style6">
                &nbsp;</td>
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

