$(document).ready(function () {
    sendDataAjax();
});
var tabla, data;

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
            data[i].Email,
            data[i].Telefono,
            data[i].Direccion,
            data[i].PorComision,
            data[i].FechaIngreso,
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
    $("#HdIDMozo").val(data[0]);
    $("#txtNombreAct").val(data[1]);
    $("#txtApellidoAct").val(data[2]);
    $("#cboTipoDocAct").val(data[3]);
    $("#txtDocumentoAct").val(data[4]);
    $("#txtEmailAct").val(data[5]);
    $("#txtTelefonoAct").val(data[6]);
    $("#txtDireccionAct").val(data[7]);
    $("#txtComisionAct").val(data[8]);
    $("#txtFechaIngresoAct").val(data[9]);

}

$(document).on('click', '#eliminar', function (e) {
    e.preventDefault();
    let row = $(this).parent().parent();
    data = tabla.fnGetData(row);
    fillModalDataEliminar();

});

function fillModalDataEliminar() {
    $("#hdIdMozoElim").val(data[0]);
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