<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Local.aspx.cs" Inherits="Confiteria.Local" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <button type="button" class="btn btn-primary btn-lg" data-bs-toggle="modal" data-bs-target="#modalRegistrar" onclick="abrirModalRegistrar()" id="btnAbrirModalRegistrar"><span class="fa fa-user"></span> Registrar Local</button>
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
                    <table class="table table-bordered" id="tblLocales" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Codigo</th>
                                <th>Razon Social</th>
                                <th>Direccion</th>
                                <th>CUIT</th>
                                <th>Tipo IVA</th>
                                <th>Ingreso Bruto</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Codigo</th>
                                <th>Razon Social</th>
                                <th>Direccion</th>
                                <th>CUIT</th>
                                <th>Tipo IVA</th>
                                <th>Ingreso Bruto</th>
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
                    <h5 class="modal-title" id="modalRegistrarLabel2">Registrar Local</h5>
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
                            <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="form-control" placeholder="Razon Social" pattern="[A-Za-z]{3,25}" title="Debe ingresar solo letras, un minimo de 3 caracters y un maximo de 25"/> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Direccion" pattern="[A-Za-z]{3,25}" title="Debe ingresar solo letras, un minimo de 3 caracters y un maximo de 25" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtCuit" CssClass="form-control" placeholder="Cuit" pattern="[0-9]{11,11}" title ="Debe ingresar solo numeros del 0 al 9 (para un cuit valido debe ingresar 11 caracteres)"/> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtIngBrutos" CssClass="form-control" placeholder="Ingresos Brutos" pattern="[A-Za-z0-9.]" title="Debe ingresar numeros enteros o decimales"/> 
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboTipoIva" CssClass="form-control"></asp:DropDownList> 
                        </div>
                    </div>
                   
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnRegistrar_Click" OnClientClick="clearTabla(); sendDataAjax();"/>

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
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar Local</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                    
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDLocal" runat="server" />
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtRazonSocialAct" CssClass="form-control" placeholder="Razon Social" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDireccionAct" CssClass="form-control" placeholder="Direccion" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtCuitAct" CssClass="form-control" placeholder="Cuit" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtIngBrutoAct" CssClass="form-control" placeholder="Ingresos Brutos" pattern="/^\d+(?:\.\d{1,2})?$/"/> 
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboTipoIvaAct" CssClass="form-control"></asp:DropDownList> 
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">

                     <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary" data-bs-dismiss="modal" runat="server" OnClick="btnActualizar_Click" OnClientClick="clearTabla(); sendDataAjax();"/>

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
                    <h5 class="modal-title" id="staticBackdropLabel2">Eliminar Local</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hdIdLocalElim" runat="server" />
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
    <script src="js/Local.js"></script>



    <script>
        $(document).ready(function () {
            sendDataAjax();
        });
        var tabla, data;


        //Validaciones

        let razonSocial = document.getElementById('<%=txtRazonSocial.ClientID%>').value;
        let direccion = document.getElementById('<%=txtDireccion.ClientID%>').value;
        let cuit = document.getElementById('<%=txtCuit.ClientID%>').value;
        var tipoIva = document.getElementById('<%=cboTipoIva.ClientID%>').selectedIndex;
        let ingBruto = document.getElementById('<%=txtIngBrutos.ClientID%>').value;

        function validacionRegistro() {
            if (razonSocial === "" || razonSocial === undefined) {
                swal('Debe completar todos los campos');
            }
            if (direccion === "" || direccion === undefined) {
                swal('Debe completar todos los campos');
            }
            if (cuit === "" || cuit === undefined) {
                swal('Debe completar todos los campos');
            }
            if (tipoIva > 0) {
                swal('Debe completar todos los campos');
            }
            if (ingBruto === "" || ingBruto === undefined) {
                swal('Debe completar todos los campos');
            }
            console.log(descripcion, precio, stock,rubro);
        }

        let razonSocialAct = document.getElementById('<%=txtRazonSocialAct.ClientID%>').value;
        let direccionAct = document.getElementById('<%=txtDireccionAct.ClientID%>').value;
        let cuitAct = document.getElementById('<%=txtCuitAct.ClientID%>').value;
        var tipoIvaAct = document.getElementById('<%=cboTipoIvaAct.ClientID%>').selectedIndex;
        let ingBrutoAct = document.getElementById('<%=txtIngBrutoAct.ClientID%>').value;

        function validacionActualizar() {
            if (razonSocialAct === "" || razonSocialAct === undefined) {
                swal('Debe ingresar un Nombre de Articulo');
            }
            if (direccionAct === "" || direccionAct === undefined) {
                swal('Debe ingresar un Precio');
            }
            if (cuitAct === "" || cuitAct === undefined) {
                swal('Debe ingresar un Stock');
            }
            if (tipoIvaAct === 0) {
                swal('Debe ingresar un Nombre de Articulo');
            }
            if (ingBrutoAct === "" || ingBrutoAct === undefined) {
                swal('Debe ingresar un Stock');
            }
            
        }

        //Fin Validaciones

        function addRowDT(data) {
            tabla = $("#tblLocales").dataTable();
            //tabla.fnClearTable();
            for (var i = 0; i <= data.length; i++) {
                tabla.fnAddData([
                    data[i].IdLocal,
                    data[i].RazonSocial,
                    data[i].Direccion,
                    data[i].Cuit,
                    data[i].IdTipoIva,
                    data[i].IngBruto,
                    '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'

                ])
            }
        }

        function sendDataAjax() {
            $.ajax({
                type: "POST",
                url: "Local.aspx/listaLocales",
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
            $("#<%=HdIDLocal.ClientID%>").val(data[0]);
            $("#<%=txtRazonSocialAct.ClientID%>").val(data[1]);
            $("#<%=txtCuitAct.ClientID%>").val(data[2]);
            $("#<%=txtCuitAct.ClientID%>").val(data[3]);
            $("#<%=cboTipoIvaAct.ClientID%>").val(data[4]);
            $("#<%=txtIngBrutoAct.ClientID%>").val(data[5]);

        }

        $(document).on('click', '#eliminar', function (e) {
            e.preventDefault();
            let row = $(this).parent().parent();
            data = tabla.fnGetData(row);
            fillModalDataEliminar();

        });

        function fillModalDataEliminar() {
            $("#<%=hdIdLocalElim.ClientID%>").val(data[0]);
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
            swal("Error", "Ya existe un Local registrado con esos datos", "error");
        }



        //MENSAJE REGISTRO
        function MensajeSuccess() {
            swal("Muy Bien!", "Local registrado con exito", "success");
        }

        function MensajeError() {
            swal("Error", "No se pudo registrar el Local", "error");
        }

        //MENSAJE ELIMINAR
        function MensajeEliminarOk() {
            swal("Muy Bien!", "Local eliminado con exito", "success");
        }

        function MensajeErrorEliminar() {
            swal("Error", "No se pudo eliminar el Local", "error");
        }

        //MENSAJE ACTUALIZAR
        function MensajeActualizrOk() {
            swal("Muy Bien!", "Local actualizado con exito", "success");
        }

        function MensajeErrorActualizar() {
            swal("Error", "No se pudo actualizar el Local", "error");
        }
    </script>








</asp:Content>
