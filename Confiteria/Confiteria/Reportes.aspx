<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Confiteria.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" >
        <div class="card text-center">
            <div class="card-header">
                Reportes
            </div>
            <div class="card-body">
                <h5 class="card-title">Seleccione una fecha</h5>
                <div class="col-md-7 col-lg-8 mb-4" style="margin-left:180px;">
                   <input id="InputFecha" type="date" class="form-control" runat="server">
                   <%--<asp:Button ID="btnNuevaBusqueda" Text="Nueva busqueda" runat="server" class="form-control btn btn-primary rounded submit px-3 mt-3" OnClick="btnNuevaBusqueda_Click" />--%>
               </div>
                <%--<a href="#" class="btn btn-primary">Nueva Busqueda</a>--%>
            </div>
            <div class="card-footer text-muted">
                <asp:Label ID="lblFecha" Text="" runat="server" />
            </div>
        </div>

        <div class="mt-3">
            <asp:Button ID="btnReporteArticulo" Text="Ventas por Articulo" runat="server" CssClass="btn btn-dark btn-lg mr-2" OnClick="btnReporteArticulo_Click" />
            <asp:Button ID="btnReporteMozo" Text="Ventas por Mozo" runat="server" CssClass="btn btn-dark btn-lg" OnClick="btnReporteMozo_Click" />
        </div>

        <div class="card mt-4" id="descargarReporteArticulo">
            <h5 class="card-header">Ventas por Articulo</h5>
            <div class="card-body">
                <%-- contenido --%>
                <asp:GridView ID="gvVentsArticulo" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="CodArticulo" HeaderText="Articulo" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" HeaderStyle-CssClass="table-dark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col">
                <button id="btnDescargarReporteArt" class="btn btn-dark float-right" onclick="printDiv('descargarReporteArticulo')">
                    Descargar
                </button>
            </div>
        </div>

        <div class="card mt-4" id="descargarReporteMozo">
            <h5 class="card-header">Ventas Por Mozo</h5>
            <div class="card-body">
                <%-- contenido --%>
                <asp:GridView ID="gvVentasMozo" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="Mozo" HeaderText="Mozo" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="CantidadArt" HeaderText="Cantidad Articulos" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="ImpTotal" HeaderText="Importe Total" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Comision" HeaderText="Comsión" HeaderStyle-CssClass="table-dark" />
                        <asp:BoundField DataField="Apagar" HeaderText="A Pagar" HeaderStyle-CssClass="table-dark" />
                    </Columns>
                </asp:GridView>
                
            </div>
        </div>

        <div class="row mt-2">
            <div class="col">
                <button id="btnDescargar" class="btn btn-dark float-right" onclick="printDiv('descargarReporteMozo')">
                    Descargar
                </button>
            </div>
        </div>

    </div>

    <script>
        function printDiv(div) {
            // Create and insert new print section
            var elem = document.getElementById(div);
            var domClone = elem.cloneNode(true);
            var $printSection = document.createElement("div");
            $printSection.id = "printSection";
            $printSection.appendChild(domClone);
            document.body.insertBefore($printSection, document.body.firstChild);
            var master = document.getElementById("form1");
            master.remove();
            window.print();
            window.location.href = "/Reportes.aspx"
            // Clean up print section for future use
            var oldElem = document.getElementById("printSection");
            if (oldElem != null) { oldElem.parentNode.removeChild(oldElem); }
            //oldElem.remove() not supported by IE
            return true;
        }
    </script>
    
</asp:Content>
