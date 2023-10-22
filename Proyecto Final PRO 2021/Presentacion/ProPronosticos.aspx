<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProPronosticos.aspx.cs" Inherits="ProPronosticos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            height: 22px;
        }
        .style6
        {
            width: 631px;
            height: 22px;
            text-align: center;
        }
        .style7
        {
            height: 23px;
            width: 373px;
        }
        .style8
        {
            width: 688px;
            height: 23px;
            text-align: center;
        }
        .style9
        {
            height: 23px;
            width: 279px;
            text-align: center;
        }
        .style10
        {
            width: 279px;
            text-align: center;
        }
        .style11
        {
            height: 22px;
            width: 279px;
            text-align: center;
        }
        .style12
        {
            height: 30px;
            width: 373px;
        }
        .style14
        {
            width: 279px;
            text-align: center;
            height: 30px;
        }
        .style15
        {
            width: 373px;
        }
        .style16
        {
            width: 688px;
            text-align: left;
            height: 30px;
        }
        .style17
        {
            width: 688px;
            text-align: center;
            height: 30px;
        }
        .style18
        {
            width: 373px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Pronosticos" style="text-align: center"></asp:Label>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    <asp:GridView ID="GRID" runat="server" Width="677px" 
                        AutoGenerateColumns="False" Height="109px" 
                        onselectedindexchanged="GRID_SelectedIndexChanged" 
                        style="text-align: center; margin-right: 0px" CellPadding="4" 
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CodigoCiudad" HeaderText="CodigoCiudad" />
                            <asp:BoundField DataField="NombreCiudad" HeaderText="NombreCiudad" />
                            <asp:BoundField DataField="UnPais.CodigoPais" HeaderText="CodigoPais" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    <asp:Label ID="Label2" runat="server" Text="Temperatura Maxima: " 
                        Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTemperaturaMax" runat="server"></asp:TextBox>
                </td>
                <td class="style16">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Tipo de Cielo:" 
                        Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox 
                        ID="txtTipodeCielo" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" 
                        Text="Ej: Despejado, Parcialmente Nuboso, Nuboso."></asp:Label>
                </td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Hora"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtHora" runat="server" style="text-align: center"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    <asp:Label ID="Label3" runat="server" Text="Temperatura Minima:" 
                        Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTemperaturaMin" runat="server"></asp:TextBox>
                </td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Fecha"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    <asp:Label ID="Label4" runat="server" Text="Velocidad Viento:" Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtVelocidadViento" runat="server"></asp:TextBox>
                </td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label5" runat="server" Text="Probabilidad Lluvia:" 
                        Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtProbabilidadLluvia" runat="server"></asp:TextBox>
                </td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style14">
                    </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="lblInfo" runat="server"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Refresh" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                </td>
                <td class="style16">
                </td>
                <td class="style11">
                </td>
            </tr>
            <tr>
                <td class="style7">
                </td>
                <td class="style8">
                </td>
                <td class="style9">
                </td>
            </tr>
            <tr>
                <td class="style15">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style10">
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
    <p>
    </p>
</asp:Content>

