$(document).ready(function () {
    sendDataAjax();
});
var tabla, data;

function addRowDT(data) {
    tabla = $("#tblUsuarios").dataTable();
    //tabla.fnClearTable();
    for (var i = 0; i <= data.length; i++) {
        tabla.fnAddData([
            data[i].Id,
            data[i].Nombre,
            data[i].Apellido,
            data[i].IdTipoDoc,
            data[i].NumeroDoc,
            data[i].NombreUsuario,
            data[i].Password,
            data[i].IdRol,
            '<button type="button" value="Actualizar" class="btn btn-primary" style="width:120px" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit">Actualizar</button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" style="width:120px" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()">Eliminar</button>'

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

//CAGAR DATOS EN EL MODAL
function fillModalData() {
    $("#idProcedencia").val(data[0]);
    $("#txtNombreActualizar").val(data[1]);
}

$(document).on('click', '#eliminar', function (e) {
    e.preventDefault();
    let row = $(this).parent().parent();
    data = tabla.fnGetData(row);
    fillModalDataEliminar();

});

function fillModalDataEliminar() {
    $("#idProcedenciaEliminar").val(data[0]);
}


//Cerrar Modal Eliminar
function cerrarModalEliminar() {
    $('#staticBackdrop2').modal('hide');
}

//Abrir modal Eliminar
function abrirModalEliminar() {
    $('#staticBackdrop2').modal('show');
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
function cerrarModalActualizar() {
    $('#modalRegistrar').modal('hide');
}


function MensajeErrorValidacion() {
    swal("Error", "Ya existe un usuario con esos datos", "error");
}

function MensajeSuccess() {
    swal("Muy Bien!", "Usuario registrado con exito", "success");
}

function MensajeError() {
    swal("Error", "No se pudo registrar el Usuario", "error");
}