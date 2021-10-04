<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Confiteria.Articulos" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <button type="button" class="btn btn-primary btn-lg" data-bs-toggle="modal" data-bs-target="#modalRegistrar" onclick="abrirModalRegistrar()" id="btnAbrirModalRegistrar"><span class="fa fa-user"></span> Registrar Articulo</button>
    </div>
    <br />
    

    <%-- DATATABLE  --%>

    <div class="container">
        
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary"> Lista de Articulos</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="tblArticulos" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Codigo</th>
                                <th>Descripcion</th>
                                <th>Precio</th>
                                <th>Stock</th>
                                <th>Rubro</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Codigo</th>
                                <th>Descripcion</th>
                                <th>Precio</th>
                                <th>Stock</th>
                                <th>Rubro</th>
                                <th>Acciones</th>
                            </tr>
                        </tfoot>
                        <tbody>
                            
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Registrar -->
    <div class="modal fade" id="modalRegistrar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalRegistrarLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalRegistrarLabel2">Registrar Articulo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

               
                
                <div class="modal-body">
                    <%--<asp:HiddenField ID="HdIDUsuario" runat="server" />--%>
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Nombre Articulo" type="text"/>
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorDescripcion" />
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Precio" />
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorPrecio" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtStock" CssClass="form-control" placeholder="Stock" /> 
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorStock" />
                        </div>
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRubro" CssClass="form-control"></asp:DropDownList> 
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorRubro" />
                        </div>
                    </div>
                   
                </div>
                

        
                <div class="modal-footer">
                    
                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary"  runat="server" OnClick="btnRegistrar_Click"/>
                    
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalRegistrar()">Cerrar</button>
                </div>
            
            </div>
        </div>
    </div>


    <!-- Modal Actualizar -->
    <div class="modal fade" id="modalActualizar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalActualizarLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar Articulo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDArticulo" runat="server" />
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDescripcionAct" CssClass="form-control" placeholder="Nombre Articulo" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPrecioAct" CssClass="form-control" placeholder="Precio" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtStockAct" CssClass="form-control" placeholder="Stock" /> 
                        </div>
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRubroAct" CssClass="form-control"></asp:DropDownList> 
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnActualizar_Click" />

                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalActualizar()">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Eliminar -->
    <div class="modal fade" id="modalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel2">Eliminar Mozo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hdIdArticuloElim" runat="server" />
                            <label>¿Esta seguro de Eliminar el Articulo?</label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button Text="Eliminar" CssClass="btn btn-primary" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalEliminar()">Cerrar</button>
                        </div>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>

            </div>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
    <script src="https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="js/Articulo.js"></script>
</asp:Content>
