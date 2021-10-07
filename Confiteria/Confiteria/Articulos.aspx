<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Confiteria.Articulos" %>
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

               
                <asp:UpdatePanel runat="server">
        <ContentTemplate>  

        
                <div class="modal-body">
                    <%--<asp:HiddenField ID="HdIDUsuario" runat="server" />--%>
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Nombre Articulo" type="text" pattern="^[A-Za-z0-9 ]{3,25}" title="Debe ingresar solo letras o numeros, un minimo de 3 caracters y un maximo de 25"/>
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorDescripcion" />
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" placeholder="Precio" pattern="[0-9,]{1,8}" title="Debe ingresar numeros enteros o decimales" />
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorPrecio" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                        <asp:TextBox runat="server" ID="txtStock" CssClass="form-control" placeholder="Stock"
                            pattern="[0-9]{1,8}" title="Debe ingresar solo numeros del 0 al 9 " />
                        <asp:Label Text="" runat="server" Visible="false" ID="lblErrorStock" />
                    </div>
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRubro" CssClass="form-control"></asp:DropDownList> 
                            <asp:Label Text="" runat="server" Visible ="false" ID="lblErrorRubro" />
                        </div>
                    </div>
                   
                </div>
                

        
                <div class="modal-footer">
                    
                     <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary"  runat="server" OnClick="btnRegistrar_Click" />
                    
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
                    <h5 class="modal-title" id="modalActualizarLabel2">Actualizar Articulo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <asp:UpdatePanel runat="server">
            <ContentTemplate>

            
                <div class="modal-body">
                    <asp:HiddenField ID="HdIDArticulo" runat="server" />
                    
                    <div class="row">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDescripcionAct" CssClass="form-control" placeholder="Nombre Articulo" pattern="^[A-Za-z0-9 ]{3,25}" title="Debe ingresar solo letras o numeros, un minimo de 3 caracters y un maximo de 25" /> 
                        </div>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtPrecioAct" CssClass="form-control" placeholder="Precio" pattern="[0-9,]{1,8}" title="Debe ingresar numeros enteros o decimales" />
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtStockAct" CssClass="form-control" placeholder="Stock" pattern="[0-9]{1,8}" title="Debe ingresar solo numeros del 0 al 9 " /> 
                        </div>
                        <div class="col">
                            <asp:DropDownList runat="server" ID="cboRubroAct" CssClass="form-control"></asp:DropDownList> 
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
    <%--<script src="js/Articulo.js"></script>--%>
    <script>
        $(document).ready(function () {
            //tabla.fnClearTable();
            sendDataAjax();
        });
        var tabla, data;


        //Validaciones

        let descripcion = document.getElementById('<%=txtDescripcion.ClientID%>').value;
        let precio = document.getElementById('<%=txtPrecio.ClientID%>').value;
        let stock = document.getElementById('<%=txtStock.ClientID%>').value;
        var rubro = document.getElementById('<%=cboRubro.ClientID%>').selectedIndex;

        function validacionRegistro() {
            if (descripcion === "" || descripcion === undefined) {
                swal('Debe completar todos los campos');
            }
            if (precio === "" || precio === undefined) {
                swal('Debe completar todos los campos');
            }
            if (stock === "" || stock === undefined) {
                swal('Debe completar todos los campos');
            }
            if (rubro > 0) {
                swal('Debe completar todos los campos');
            }
            console.log(descripcion, precio, stock,rubro);
        }

        let descripcionAct = document.getElementById('<%=txtDescripcionAct.ClientID%>').value;
        let precioAct = document.getElementById('<%=txtPrecioAct.ClientID%>').value;
        let stockAct = document.getElementById('<%=txtStockAct.ClientID%>').value;
        var rubroAct = document.getElementById('<%=cboRubroAct.ClientID%>').selectedIndex;

        function validacionActualizar() {
            if (descripcionAct === "" || descripcionAct === undefined) {
                swal('Debe ingresar un Nombre de Articulo');
            }
            if (precioAct === "" || precioAct === undefined) {
                swal('Debe ingresar un Precio');
            }
            if (stockAct === "" || stockAct === undefined) {
                swal('Debe ingresar un Stock');
            }
            if (rubroAct === 0) {
                swal('Debe ingresar un Nombre de Articulo');
            }
        }

        //Fin Validaciones

        function clearTabla() {
            tabla.fnClearTable();
        }

        function addRowDT(data) {
            tabla = $("#tblArticulos").dataTable();
            /*tabla.fnClearTable();*/
            for (var i = 0; i <= data.length; i++) {
                tabla.fnAddData([
                    data[i].IdArticulo,
                    data[i].Descripcion,
                    data[i].Precio,
                    data[i].Stock,
                    data[i].IdRubro,
                    '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'

                ])
            }
        }

        function sendDataAjax() {
            $.ajax({
                type: "POST",
                url: "Articulos.aspx/listaArticulos",
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
            $("#<%=HdIDArticulo.ClientID%>").val(data[0]);
            $("#<%=txtDescripcionAct.ClientID%>").val(data[1]);
            $("#<%=txtPrecioAct.ClientID%>").val(data[2]);
            $("#<%=txtStockAct.ClientID%>").val(data[3]);
            $("#<%=cboRubroAct.ClientID%>").val(data[4]);
        }

        $(document).on('click', '#eliminar', function (e) {
            e.preventDefault();
            let row = $(this).parent().parent();
            data = tabla.fnGetData(row);
            fillModalDataEliminar();

        });

        function fillModalDataEliminar() {
            $("#<%=hdIdArticuloElim.ClientID%>").val(data[0]);
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


        function MensajeValidacion() {
            swal("Error", "Debe completar todos los campos", "error");
        }

        function MensajeErrorValidacion() {
            swal("Error", "Ya existe un Articulo registrado con esos datos", "error");
        }



        //MENSAJE REGISTRO
        function MensajeSuccess() {
            swal("Muy Bien!", "Articulo registrado con exito", "success");
        }

        function MensajeError() {
            swal("Error", "No se pudo registrar el Articulo", "error");
        }

        //MENSAJE ELIMINAR
        function MensajeEliminarOk() {
            swal("Muy Bien!", "Articulo eliminado con exito", "success");
        }

        function MensajeErrorEliminar() {
            swal("Error", "No se pudo eliminar el Articulo", "error");
        }

        //MENSAJE ACTUALIZAR
        function MensajeActualizrOk() {
            swal("Muy Bien!", "Articulo actualizado con exito", "success");
        }

        function MensajeErrorActualizar() {
            swal("Error", "No se pudo actualizar el Articulo", "error");
        }
        </script>
</asp:Content>
