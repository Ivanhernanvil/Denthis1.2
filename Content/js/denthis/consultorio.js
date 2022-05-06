/// Genera un modal para agregar un registro de consultorio en la base de datos.
function abrirModal(id) {
    var url = "https://localhost:44361/Consultorio/Formulario?id=" + id;
    $.get(url, function (data) {
        $('#myModal').html(data);
        $('#myModal').modal({ backdrop: 'static', keyboard: false });
        $('#myModal').modal('show');
    })
}

/// Guarda un registro de consultorio en la base de datos.
function guardar() {
    var id = $('#idConsultorio').val();
    var nombre = $('#nombre').val();
    var direccion = $('#direccion').val();
    var horario = $('#horario').val();

    $.ajax({
        url: "https://localhost:44361/Consultorio/Guardar",
        data: { id: id, nombre: nombre, direccion: direccion, horario: horario },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de consultorio');
            }
        }
    });
}

/// Elimina un registro de consultorio de la base de datos 
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Consultorio/Eliminar",
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