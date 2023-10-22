<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PROPronosticoPorCiudad.aspx.cs" Inherits="PROPronosticoPorCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 128px;
        }
        .style8
        {
            width: 1208px;
            text-align: center;
        }
        .style9
        {
            width: 128px;
            height: 26px;
        }
        .style10
        {
            width: 1208px;
            text-align: center;
            height: 26px;
        }
        .style11
        {
            height: 26px;
        }
        .style12
        {
            width: 128px;
            height: 23px;
        }
        .style13
        {
            width: 1208px;
            text-align: center;
            height: 23px;
        }
        .style14
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                <asp:DropDownList ID="ddlPais" runat="server" 
                    onselectedindexchanged="ddlPais_SelectedIndexChanged1" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style10">
                    <asp:GridView ID="GRID" runat="server" Width="677px" 
                        AutoGenerateColumns="False" Height="109px" 
                        onselectedindexchanged="GRID_SelectedIndexChanged" 
                        style="text-align: center; margin-right: 0px" CellPadding="4" 
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CodigoCiudad" HeaderText="CodigoCiudad" />
                            <asp:BoundField DataField="NombreCiudad" HeaderText="NombreCiudad" />
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
            <td class="style11">
            </td>
        </tr>
        <tr>
            <td class="style12">
                </td>
            <td class="style13">
                </td>
            <td class="style14">
                </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                <asp:GridView ID="gvCiudadPronosticos" runat="server" AutoGenerateColumns="False" 
                    CaptionAlign="Bottom" CellPadding="4" CssClass="Grind" ForeColor="#333333" 
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CodRegistro" HeaderText="CodRegistro" />
                        <asp:BoundField DataField="UnaCiudad" HeaderText="CodigoCiudad" />
                        <asp:BoundField DataField="unUsuario" HeaderText="NombreLogueo" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Hora" HeaderText="Hora" />
                        <asp:BoundField DataField="TemperaturaMax" HeaderText="TemperaturaMax" />
                        <asp:BoundField DataField="TemperaturaMin" HeaderText="TemperaturaMin" />
                        <asp:BoundField DataField="VelocidadViento" HeaderText="VelocidadViento" />
                        <asp:BoundField DataField="TipodeCielo" HeaderText="TipodeCielo" />
                        <asp:BoundField DataField="ProbabilidadLluvia" 
                            HeaderText="ProbabilidadLluvia" />
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                <asp:Label ID="lblError" runat="server" style="text-align: center"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

