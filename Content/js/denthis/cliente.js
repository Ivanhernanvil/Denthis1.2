/// Genera un modal para agregar un nuevo registro de cliente (formulario).
function abrirModal(id) {
    var url = "https://localhost:44361/Cliente/Formulario?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

///Guarda un registro de cliente en la base de datos.
function guardar() {
    var id = $('#idCliente').val();
    var nombre = $('#nombre').val();
    var telefono = $('#telefono').val();
    var correo = $('#correo').val();
    var contrasena = $('#contrasena').val();

    $.ajax({
        url: "https://localhost:44361/Cliente/Guardar",
        data: { id: id, nombre: nombre, telefono: telefono, correo: correo, contrasena: contrasena },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de estado');
            }
        }
    });
}

/// Elimina un registro de cliente en la base de datos.
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Cliente/Eliminar",
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