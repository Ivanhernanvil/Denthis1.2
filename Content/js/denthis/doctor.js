/// Genera un modal para agregar un registro de doctor.
function abrirModal(id) {
    var url = "https://localhost:44361/Doctor/Formulario?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

/// Guarda un registro de doctor.
function guardar() {
    var id = $('#idDoctor').val();
    var nombre = $('#nombre').val();
    var especialidad = $('#especialidad').val();
    var consultorio = $('#consultorio').val();

    $.ajax({
        url: "https://localhost:44361/Doctor/Guardar",
        data: { id: id, nombre: nombre, especialidad: especialidad, consultorio: consultorio},
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de doctor');
            }
        }
    });
}

/// Elimina un registro de doctor.
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Doctor/Eliminar",
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