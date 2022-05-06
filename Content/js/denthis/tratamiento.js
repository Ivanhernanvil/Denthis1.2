/// Genera un modal para añadir un registro de tratamiento.
function abrirModal(id) {
    var url = "https://localhost:44361/Tratamiento/Formulario?id="+id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

/// Guarda un registro de tratamiento.
function guardar() {
    var id = $('#idTratamiento').val();
    var nombre = $('#nombre').val();
    var precio = $('#precio').val();

    $.ajax({
        url: "https://localhost:44361/Tratamiento/Guardar",
        data: { id: id, nombre: nombre, precio: precio },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de estado');
            }
        }
    });
}

/// Elimina un registro de tratamiento.
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Tratamiento/Eliminar",
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