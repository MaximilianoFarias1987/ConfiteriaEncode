<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="GenerarTicket.aspx.cs" Inherits="Confiteria.GenerarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    

    <div class="container" id="descargar">
        <h3>Ticket</h3>
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
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" patpattern="[0-9]{8,8}" title ="Debe ingresar solo numeros del 0 al 9"/>

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
                <%--<asp:UpdatePanel runat="server">
                    <ContentTemplate>--%>
                        <asp:Button ID="btnCargarTabla" Text="Agregar Articulo" CssClass="btn btn-primary float-right" runat="server" OnClick="btnCargarTabla_Click" />
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                        
            </div>
        </div>
        <div class="row mt-2">
            <div class="col">
                <button id="btnDescargar" class="btn btn-dark float-right" onclick="printDiv('descargar')">
                    Descargar
                </button>
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
                <asp:Label ID="lblTotal" runat="server" Text="" CssClass="float-lg-right " Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label> 
                <asp:Label ID="lblMsjTotal" runat="server" Text="" CssClass="float-lg-right mr-2 mt-2" Visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label>
                
           </div>
            
        </div>

        
        <div class="row mt-2">
            
            <div class="col">
                        <asp:Button ID="btnGenerarTicket" Text="Generar Ticket" CssClass="btn btn-primary float-right" runat="server" OnClick="btnGenerarTicket_Click" Visible="false" />
                
            </div>
            
        </div>

    </div>










    <%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
    <script src="https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="js/Ticket.js"></script>

    <script>
        $(document).ready(function () {
            console.log(cantidad);
        });

        //Validaciones
        var cantidad = document.getElementById('<%=txtCantidad.ClientID%>').value;
        let articulo = document.getElementById('<%=cboArticulos.ClientID%>').selectedIndex;
        let formaPago = document.getElementById('<%=cboFormaPago.ClientID%>').selectedIndex;
        var mozo = document.getElementById('<%=cboMozo.ClientID%>').selectedIndex;

        function validacionGenerarTicket() {
            if (formaPago === 0) {
                arti('Debe seleccionar una Forma de Pago');
            }
            if (mozo === 0) {
                swal('Debe seleccionar un Mozo');
            }
        }
        

        function validacionAgregarAlCarro() {
            if (articulo === 0) {
                swal('Debe seleccionar un Articulo');
            }
            if (cantidad === "" || cantidad === undefined) {
                swal('Debe ingresar una cantidad');
            }
        }

        

        console.log(cantidad);

    //Fin Validaciones
    </script>
    
</asp:Content>


