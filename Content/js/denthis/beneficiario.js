/// Llama a un modal para agregar un objeto de tipo beneficiario
function abrirModal(id) {
    var url = "https://localhost:44361/Beneficiario/Formulario?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        if ($('#modal').modal('show')) { console.log('Success'); }
    })
}

/// Guarda un registro de beneficiario en la base de datos
function guardar() {
    var id = $("#idBeneficiario").val();
    var nombre = $("#nombre").val();
    var apellidoPaterno = $("#apellidoPaterno").val();
    var apellidoMaterno = $("#apellidoMaterno").val();
    var edad = $("#edad").val();
    var sexo = $("#sexo").val();
    var cliente = $("#cliente").val();
    
    $.ajax({
        url: "https://localhost:44361/Beneficiario/Guardar",
        data: { id: id, nombre: nombre, apellidoPaterno: apellidoPaterno, apellidoMaterno: apellidoMaterno, edad: edad, sexo: sexo, cliente: cliente },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de cita');
            }
        }
    });
}

/// Función que elimina un registro de tipo beneficiario
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Beneficiario/Eliminar",
            data: { id: id },
            success: function (data) {
                if (data) {
                    alert("El registro fue eliminado correctamente")
                    location.reload();
                } else {
                    alert('El registro no pudo ser eliminado. Es posible que tenga relacion con otro registro');
                }
            }
        });

    }
}