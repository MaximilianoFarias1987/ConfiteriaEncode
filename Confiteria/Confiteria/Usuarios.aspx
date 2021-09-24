<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Confiteria.Usuarios" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Usuarios</h1>
    <div class="container">
        <button type="button" class="btn btn-primary btn-lg" data-bs-toggle="modal" data-bs-target="#modalRegistrar" onclick="abrirModalRegistrar()" id="btnAbrirModalRegistrar"><span class="fa fa-user"></span> Registrar Usuario</button>
    </div>
    <br />
    

    <%-- DATATABLE  --%>

    <div class="container">
        <%--<h1 class="h3 mb-2">Lista de Usuarios</h1>--%>

        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary"> Lista de Usuarios</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="tblUsuarios" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Tipo Documento</th>
                                <th>Documento</th>
                                <th>Usuario</th>
                                <th>Contraseña</th>
                                <th>Rol</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Tipo Documento</th>
                                <th>Documento</th>
                                <th>Usuario</th>
                                <th>Contraseña</th>
                                <th>Rol</th>
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
                    <h5 class="modal-title" id="modalRegistrarLabel2">Registrar Usuario</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDUsuario" runat="server" />
                    
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
                            <asp:DropDownList runat="server" ID="cboTipoDoc" CssClass="form-control">
                            <asp:ListItem Text="Seleccione un tipo de documento..." />
                            <asp:ListItem Text="DNI" />
                            <asp:ListItem Text="LC" />
                            <asp:ListItem Text="PASAPORTE" />
                        </asp:DropDownList> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNumDocumento" CssClass="form-control" placeholder="Numero Documento" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre Usuario" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Contraseña" type="password" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRol" CssClass="form-control">
                            <asp:ListItem Text="Seleccione un Rol de Usuario..." />
                            <asp:ListItem Text="ADMINISTRADOR" />
                            <asp:ListItem Text="CAJERO" />
                        </asp:DropDownList> 
                        </div>
                        
                    </div>
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnRegistrar_Click" />

                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalActualizar()">Cerrar</button>
                </div>
                <%--</ContentTemplate>--%>
                <%--                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>


    <!-- Modal Actualizar -->
    <div class="modal fade" id="modalActualizar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalActualizarLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
               
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <div class="modal-body">
                            <asp:HiddenField ID="idProcedencia" runat="server" />
                            <label>Nombre de Institucion</label>
                            <asp:TextBox ID="txtNombreActualizar" runat="server" CssClass="form-control" type="text"/>
                        </div>
                        <div class="modal-footer">

                           <%-- <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-secondary" data-bs-dismiss="modal" runat="server" OnClick="btnActualizar_Click" />--%>
                            
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalActualizar()">Cerrar</button>
                        </div>
                    <%--</ContentTemplate>--%>
<%--                </asp:UpdatePanel>--%>

            </div>
        </div>
    </div>

    <!-- Modal Eliminar -->
    <div class="modal fade" id="staticBackdrop2" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel2">ELIMINAR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                <%--<asp:Upda<%--tePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>--%>
                        <div class="modal-body">
                            <asp:HiddenField ID="idProcedenciaEliminar" runat="server" />
                            <label>¿Esta seguro de Eliminar el registro?</label>
                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button Text="Eliminar" CssClass="btn btn-primary" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click1" />--%>
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
    <script src="js/Usuario.js"></script>
</asp:Content>
