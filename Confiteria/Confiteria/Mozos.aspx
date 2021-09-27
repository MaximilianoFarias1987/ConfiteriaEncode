<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Mozos.aspx.cs" Inherits="Confiteria.Mozos" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h1>Mozos</h1>--%>

    <div class="container">
        <button type="button" class="btn btn-primary btn-lg" data-bs-toggle="modal" data-bs-target="#modalRegistrar" onclick="abrirModalRegistrar()" id="btnAbrirModalRegistrar"><span class="fa fa-user"></span> Registrar Mozo</button>
    </div>
    <br />
    

    <%-- DATATABLE  --%>

    <div class="container">
        <%--<h1 class="h3 mb-2">Lista de Usuarios</h1>--%>

        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary"> Lista de Mozos</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="tblMozos" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Tipo Documento</th>
                                <th>Documento</th>
                                <th>Email</th>
                                <th>Telefono</th>
                                <th>Direccion</th>
                                <th>% Comision</th>
                                <th>Fecha Ingeso</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Tipo Documento</th>
                                <th>Documento</th>
                                <th>Email</th>
                                <th>Telefono</th>
                                <th>Direccion</th>
                                <th>% Comision</th>
                                <th>Fecha Ingeso</th>
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
                    <h5 class="modal-title" id="modalRegistrarLabel2">Registrar Mozo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="modal-body">
                    <%--<asp:HiddenField ID="HdIDUsuario" runat="server" />--%>
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Apellido" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboTipoDoc" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNumDocumento" CssClass="form-control" placeholder="Numero Documento" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Telefono" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Direccion" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtComision" CssClass="form-control" placeholder="% Comision" />
                        </div>
                        
                    </div>
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnRegistrar_Click" />

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
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar Mozo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDMozo" runat="server" />
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombreAct" CssClass="form-control" placeholder="Nombre" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtApellidoAct" CssClass="form-control" placeholder="Apellido" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboTipoDocAct" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDocumentoAct" CssClass="form-control" placeholder="Numero Documento" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtEmailAct" CssClass="form-control" placeholder="Email" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtTelefonoAct" CssClass="form-control" placeholder="Telefono" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDireccionAct" CssClass="form-control" placeholder="Direccion" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtComisionAct" CssClass="form-control" placeholder="% Comision" />
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
                            <asp:HiddenField ID="hdIdMozoElim" runat="server" />
                            <label>¿Esta seguro de Eliminar el Mozo?</label>
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
    <script src="js/Mozo.js"></script>
</asp:Content>
