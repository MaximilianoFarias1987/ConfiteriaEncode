<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="GenerarTicket.aspx.cs" Inherits="Confiteria.GenerarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Generar Ticket</h1>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DropDownList runat="server" ID="cboArticulos" CssClass="form-control" OnSelectedIndexChanged="cboArticulos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
                
            </div>

            <div class="col">
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Precio" />
            </div>
        </div>
        <div class="row mt-2">
            <div class="col">
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" />
            </div>
            <div class="col">
                <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control" placeholder="Total" Enabled="false" />
            </div>
        </div>

        <div class="row mt-2">
            <div class="col">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnCargarTabla" Text="Agregar Articulo" CssClass="btn btn-primary float-right" runat="server" OnClick="btnCargarTabla_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
        </div>


        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvCarrito" runat="server"></asp:GridView>
                <asp:Table ID="tblCarro" runat="server" Width="82px">
                </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--<div class="modal-footer d-flex justify-content-center">
           <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
           <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Venta" CssClass="btn login_btn" UseSubmitBehavior="False" OnClick="btnFinalizar_Click" />
       </div>--%>
    </div>



   







    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
    <script src="https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
