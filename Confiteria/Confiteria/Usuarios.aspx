<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Confiteria.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h3>Usuarios</h3>--%>
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
                                <th>Rol</th>
                                <th>Contraseña</th>
                                <th >Acciones</th>
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
                                <th>Rol</th>
                                <th>Contraseña</th>
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
                    <h5 class="modal-title" id="modalRegistrarLabel2">Registrar Usuario</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <asp:UpdatePanel runat="server">
        <ContentTemplate>

        
                <div class="modal-body">
                    <%--<asp:HiddenField ID="HdIDUsuario" runat="server" />--%>
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre" pattern="[A-Za-z]{3,25}" title="Debe ingresar solo letras, un minimo de 4 caracters y un maximo de 25"/> 
                            <%-- Exprecion regular que solo permite letras mayusculas y minusculas y como maximo 12 caracteres y minimo 4 --%>
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Apellido" pattern="[A-Za-z]{3,25}" title="Debe ingresar solo letras, un minimo de 4 caracters y un maximo de 25" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboTipoDoc" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNumDocumento" CssClass="form-control" placeholder="Numero Documento" pattern="[0-9]{8,8}" title ="Debe ingresar solo numeros del 0 al 9 (para un documento valido debe ingresar 8 caracteres)"/>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre Usuario" pattern="[A-Za-z0-9]{4,20}" title="El Nombre de Usuario solo puede contener numeros y letras. Un minimo de 8 caracteres y un maximo de 20"/>
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Contraseña" type="password" pattern="(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]){8,12}" title="La contraseña debe contener al menos una letra mayuscula, minuscula y  un valor numerico. Un minimo de 8 caracteres y un maximo de 12." />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRol" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        
                    </div>
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnRegistrar_Click" />

                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalRegistrar()">Cerrar</button>
                </div>
            </ContentTemplate>
    </asp:UpdatePanel>
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
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                    
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDUsuario" runat="server" />
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombreActualizar" CssClass="form-control" placeholder="Nombre" /> 
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
                            <asp:TextBox runat="server" ID="txtDocAct" CssClass="form-control" placeholder="Numero Documento" pattern="[0-9]+" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombreUsuarioAct" CssClass="form-control" placeholder="Nombre Usuario" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPasswordAct" CssClass="form-control" placeholder="Contraseña" type="password" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRolAct" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        
                    </div>
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnActualizar_Click" />

                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="cerrarModalActualizar()">Cerrar</button>
                </div>

                        </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal Eliminar -->
    <div class="modal fade" id="modalEliminar" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel2">ELIMINAR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hdIdUsuarioElim" runat="server" />
                            <label>¿Esta seguro de Eliminar el Usuario?</label>
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
    <%--<script src="js/Usuario.js"></script>--%>



    <script>
        $(document).ready(function () {
            sendDataAjax();
        });
        var tabla, data;


        //Validaciones

        let nombre = document.getElementById('<%=txtNombre.ClientID%>').value;
        let apellido = document.getElementById('<%=txtApellido.ClientID%>').value;
        let tipoDoc = document.getElementById('<%=cboTipoDoc.ClientID%>').selectedIndex;
        let numDoc = document.getElementById('<%=txtNumDocumento.ClientID%>').value;
        let nombUsuario = document.getElementById('<%=txtNombreUsuario.ClientID%>').value;
        let pass = document.getElementById('<%=txtPassword.ClientID%>').value;
        let rol = document.getElementById('<%=cboRol.ClientID%>').selectedIndex;

        function validacionRegistro() {
            if (nombre === "" || nombre === undefined) {
                swal('Debe completar todos los campos');
            }
            if (apellido === "" || apellido === undefined) {
                swal('Debe completar todos los campos');
            }
            if (tipoDoc === 0) {
                swal('Debe completar todos los campos');
            }
            if (numDoc === "" || numDoc === undefined) {
                swal('Debe completar todos los campos');
            }
            if (nombUsuario === "" || nombUsuario === undefined) {
                swal('Debe completar todos los campos');
            }
            if (pass === "" || pass === undefined) {
                swal('Debe completar todos los campos');
            }
            if (rol === 0) {
                swal('Debe completar todos los campos');
            }
            
            console.log(descripcion, precio, stock,rubro);
        }

        let nombreAct = document.getElementById('<%=txtNombreActualizar.ClientID%>').value;
        let apellidoAct = document.getElementById('<%=txtApellidoAct.ClientID%>').value;
        let tipoDocAct = document.getElementById('<%=cboTipoDocAct.ClientID%>').selectedIndex;
        let numDocAct = document.getElementById('<%=txtDocAct.ClientID%>').value;
        let nombUsuarioAct = document.getElementById('<%=txtNombreUsuarioAct.ClientID%>').value;
        let passAct = document.getElementById('<%=txtPasswordAct.ClientID%>').value;
        let rolAct = document.getElementById('<%=cboRolAct.ClientID%>').selectedIndex;

        function validacionActualizar() {
            if (nombreAct === "" || nombreAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (apellidoAct === "" || apellidoAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (tipoDocAct === 0) {
                swal('Debe completar todos los campos');
            }
            if (numDocAct === "" || numDocAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (nombUsuarioAct === "" || nombUsuarioAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (passAct === "" || passAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (rolAct === 0) {
                swal('Debe completar todos los campos');
            }
        }

        //Fin Validaciones

        function clearTabla() {
            tabla.fnClearTable();
        }

        //function addRowDT(data) {
        //    tabla = $("#tblUsuarios").dataTable();
        //    //tabla.fnClearTable();
        //    for (var i = 0; i <= data.length; i++) {
        //        tabla.fnAddData([
        //            data[i].Id,
        //            data[i].Nombre,
        //            data[i].Apellido,
        //            data[i].IdTipoDoc,
        //            data[i].NumeroDoc,
        //            data[i].NombreUsuario,
        //            data[i].Password,
        //            data[i].IdRol,
        //            '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'

        //        ])
        //    }
        //}

        function addRowDT(data) {
            tabla = $("#tblUsuarios").dataTable();
            //tabla.fnClearTable();
            for (var i = 0; i <= data.length; i++) {
                tabla.fnAddData([
                    data[i].IdUsuario,
                    data[i].Nombre,
                    data[i].Apellido,
                    data[i].TipoDoc,
                    data[i].Documento,
                    data[i].NombreUsuario,
                    data[i].Rol,
                    data[i].Password,
                    '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'

                ])
            }
        }

        function sendDataAjax() {
            $.ajax({
                type: "POST",
                url: "Usuarios.aspx/listaUsuarios",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    addRowDT(data.d);
                },
                error: function (response) {
                    swal(response.d);
                }
            })
        }


        //OBTENER DATOS DE UNA FILA
        $(document).on('click', '#btnAbrirModalEdit', function (e) {
            e.preventDefault();
            let row = $(this).parent().parent();
            data = tabla.fnGetData(row);
            fillModalData();

        });

        //CAGAR DATOS EN EL MODAL ACTUALIZAR
        <%--function fillModalData() {
            $("#<%=HdIDUsuario.ClientID%>").val(data[0]);
            $("#<%=txtNombreActualizar.ClientID%>").val(data[1]);
            $("#<%=txtApellidoAct.ClientID%>").val(data[2]);
            $("#<%=cboTipoDocAct.ClientID%>").val(data[3]);
            $("#<%=txtDocAct.ClientID%>").val(data[4]);
            $("#<%=txtNombreUsuarioAct.ClientID%>").val(data[5]);
            $("#<%=txtPasswordAct.ClientID%>").val(data[6]);
            $("#<%=cboRolAct.ClientID%>").val(data[7]);

        }--%>

        function fillModalData() {
            $("#<%=HdIDUsuario.ClientID%>").val(data[0]);
             $("#<%=txtNombreActualizar.ClientID%>").val(data[1]);
             $("#<%=txtApellidoAct.ClientID%>").val(data[2]);
           $("#<%=txtDocAct.ClientID%>").val(data[4]);
            $("#<%=txtNombreUsuarioAct.ClientID%>").val(data[5]);
            $("#<%=txtPasswordAct.ClientID%>").val(data[6]);

         }

        $(document).on('click', '#eliminar', function (e) {
            e.preventDefault();
            let row = $(this).parent().parent();
            data = tabla.fnGetData(row);
            fillModalDataEliminar();

        });

        function fillModalDataEliminar() {
            $("#<%=hdIdUsuarioElim.ClientID%>").val(data[0]);
        }


        //Cerrar Modal Eliminar
        function cerrarModalEliminar() {
            $('#modalEliminar').modal('hide');
        }

        //Abrir modal Eliminar
        function abrirModalEliminar() {
            $('#modalEliminar').modal('show');
        }

        //Cerrar Modal Actualizar
        function cerrarModalActualizar() {
            $('#modalActualizar').modal('hide');
        }

        //Abrir Modal Actualizar
        function abrirModalActualizar() {
            $('#modalActualizar').modal('show');
        }


        //Abrir Modal Registrar
        function abrirModalRegistrar() {
            $('#modalRegistrar').modal('show');
        }


        //Cerrar Modal Registrar
        function cerrarModalRegistrar() {
            $('#modalRegistrar').modal('hide');
        }


        function MensajeErrorValidacion() {
            swal("Error", "Ya existe un usuario con esos datos", "error");
        }



        //MENSAJE REGISTRO
        function MensajeSuccess() {
            swal("Muy Bien!", "Usuario registrado con exito", "success");
        }

        function MensajeError() {
            swal("Error", "No se pudo registrar el Usuario", "error");
        }

        //MENSAJE ELIMINAR
        function MensajeEliminarOk() {
            swal("Muy Bien!", "Usuario eliminado con exito", "success");
        }

        function MensajeErrorEliminar() {
            swal("Error", "No se pudo eliminar el Usuario", "error");
        }

        //MENSAJE ACTUALIZAR
        function MensajeActualizrOk() {
            swal("Muy Bien!", "Usuario actualizado con exito", "success");
        }

        function MensajeErrorActualizar() {
            swal("Error", "No se pudo actualizar el Usuario", "error");
        }
    </script>
</asp:Content>
