<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProCiudades.aspx.cs" Inherits="ProCiudades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 728px;
        }
        .style5
        {
            width: 382px;
            text-align: center;
        }
        .style6
        {
            text-align: center;
        }
        .style7
        {
            width: 769px;
            text-align: center;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                        Text="Ciudades"></asp:Label>
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
                    &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" 
                        Text="Codigo Ciudad"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCodigoCiudad" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Paises"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDown" runat="server" DataTextField="NombrePaises" 
                        DataValueField="CodigoPaises" Height="16px" Width="156px">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" 
                        Text="Nombre Ciudad"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtNombreCiudad" runat="server"></asp:TextBox>
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
                    &nbsp;</td>
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
                        onclick="btnAlta_Click1" />
                </td>
                <td class="style6">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                        onclick="btnBuscar_Click" />
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
                    &nbsp;</td>
                <td class="style7">
                    <asp:Button ID="btnBaja" runat="server" Text="Eliminar" 
                        onclick="btnBaja_Click" />
                </td>
                <td class="style6">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Refresh" 
                        onclick="btnLimpiar_Click1" />
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
                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click1" />
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
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>
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

