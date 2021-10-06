<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Mozos.aspx.cs" Inherits="Confiteria.Mozos"  %>
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
                                <th>Telefono</th>
                                <th>% Comision</th>
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
                                <th>Telefono</th>
                                <th>% Comision</th>
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

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                    
                <div class="modal-body">
                    <%--<asp:HiddenField ID="HdIDUsuario" runat="server" />--%>
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Nombre" pattern="[a-zA-Z]"/> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Apellido" pattern="[a-zA-Z]" />
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
                            <asp:TextBox runat="server" ID="txtComision" CssClass="form-control" placeholder="% Comision" pattern="/^\d+(?:\.\d{1,2})?$/"/>
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
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar Mozo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                    
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
                            <asp:TextBox runat="server" ID="txtTelefonoAct" CssClass="form-control" placeholder="Telefono" />
                        </div>
                        
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtComisionAct" CssClass="form-control" placeholder="% Comision" pattern="/^\d+(?:\.\d{1,2})?$/" />
                        </div>
                        
                    </div>
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnActualizar_Click" OnClientClick="clearTabla(); sendDataAjax();" />

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
        let telefono = document.getElementById('<%=txtTelefono.ClientID%>').value;
        let comision = document.getElementById('<%=txtComision.ClientID%>').value;

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
            if (telefono === "" || telefono === undefined) {
                swal('Debe completar todos los campos');
            }
            if (comision === "" || comision === undefined) {
                swal('Debe completar todos los campos');
            }
            
            console.log(descripcion, precio, stock,rubro);
        }

        let nombreAct = document.getElementById('<%=txtNombreAct.ClientID%>').value;
        let apellidoAct = document.getElementById('<%=txtApellidoAct.ClientID%>').value;
        let tipoDocAct = document.getElementById('<%=cboTipoDocAct.ClientID%>').selectedIndex;
        let numDocAct = document.getElementById('<%=txtDocumentoAct.ClientID%>').value;
        let telefonoAct = document.getElementById('<%=txtTelefonoAct.ClientID%>').value;
        let comisionAct = document.getElementById('<%=txtComisionAct.ClientID%>').value;

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
            if (telefonoAct === "" || telefonoAct === undefined) {
                swal('Debe completar todos los campos');
            }
            if (comisionAct === "" || comisionAct === undefined) {
                swal('Debe completar todos los campos');
            }
        }

        //Fin Validaciones


        function clearTabla() {
            tabla.fnClearTable();
        }

        function addRowDT(data) {
            tabla = $("#tblMozos").dataTable();
            //tabla.fnClearTable();
            for (var i = 0; i <= data.length; i++) {
                tabla.fnAddData([
                    data[i].Id,
                    data[i].Nombre,
                    data[i].Apellido,
                    data[i].IdTipoDoc,
                    data[i].NumeroDoc,
                    data[i].Telefono,
                    data[i].PorComision,
                    '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'

                ])
            }
        }

        function sendDataAjax() {
            $.ajax({
                type: "POST",
                url: "Mozos.aspx/listaMozos",
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
        function fillModalData() {
            $("#<%=HdIDMozo.ClientID%>").val(data[0]);
            $("#<%=txtNombreAct.ClientID%>").val(data[1]);
            $("#<%=txtApellidoAct.ClientID%>").val(data[2]);
            $("#<%=cboTipoDocAct.ClientID%>").val(data[3]);
            $("#<%=txtDocumentoAct.ClientID%>").val(data[4]);
            $("#<%=txtTelefonoAct.ClientID%>").val(data[5]);
            $("#<%=txtComisionAct.ClientID%>").val(data[6]);

        }

        $(document).on('click', '#eliminar', function (e) {
            e.preventDefault();
            let row = $(this).parent().parent();
            data = tabla.fnGetData(row);
            fillModalDataEliminar();

        });

        function fillModalDataEliminar() {
            $("#<%=hdIdMozoElim.ClientID%>").val(data[0]);
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
            swal("Error", "Ya existe un Mozo registrado con esos datos", "error");
        }



        //MENSAJE REGISTRO
        function MensajeSuccess() {
            swal("Muy Bien!", "Mozo registrado con exito", "success");
        }

        function MensajeError() {
            swal("Error", "No se pudo registrar el Mozo", "error");
        }

        //MENSAJE ELIMINAR
        function MensajeEliminarOk() {
            swal("Muy Bien!", "Mozo eliminado con exito", "success");
        }

        function MensajeErrorEliminar() {
            swal("Error", "No se pudo eliminar el Mozo", "error");
        }

        //MENSAJE ACTUALIZAR
        function MensajeActualizrOk() {
            swal("Muy Bien!", "Mozo actualizado con exito", "success");
        }

        function MensajeErrorActualizar() {
            swal("Error", "No se pudo actualizar el Mozo", "error");
        }
    </script>

</asp:Content>
