<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="GenerarTicket.aspx.cs" Inherits="Confiteria.GenerarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <h3>Generar Ticket</h3>
        <div class="row">
            <div class="col">
                <label>Articulo</label>
                 <%--<asp:UpdatePanel runat="server">
                    <ContentTemplate>--%>
                <asp:DropDownList runat="server" ID="cboArticulos" CssClass="form-control" OnSelectedIndexChanged="cboArticulos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>

            <div class="col">
                <label>Cantidad</label>
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" />

            </div>
        </div>

        <div class="row">
            <div class="col">
                <label>Fué atendido por</label>
                <asp:DropDownList runat="server" ID="cboMozo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col">
                <label>Forma de Pago</label>
                <asp:DropDownList runat="server" ID="cboFormaPago" CssClass="form-control"></asp:DropDownList>

            </div>
        </div>

        <div class="row mt-2">
            <div class="col">
                        <asp:Button ID="btnCargarTabla" Text="Agregar Articulo" CssClass="btn btn-primary float-right" runat="server" OnClick="btnCargarTabla_Click" />
            </div>
        </div>


        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvCarrito" runat="server" CssClass="table table-bordered table-hover  mt-5">
                    <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                </asp:GridView>
                <asp:Table ID="tblCarro" runat="server" Width="82px">
                </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>


        <div class="row mt-2">
            <div class="col">
                        <asp:Button ID="btnGenerarTicket" Text="Generar Ticket" CssClass="btn btn-primary float-right" runat="server" OnClick="btnGenerarTicket_Click" Visible="false" />
                <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            </div>
            
        </div>

    </div>










    <%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
    <script src="https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="js/Ticket.js"></script>
</asp:Content>
