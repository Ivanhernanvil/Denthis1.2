var beneficiario;

/// Genera un modal para agregar un nuevo registro de cita.
function abrirModal(id) {
    var url = "https://localhost:44361/Cita/Formulario?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

/// Abre un modal destinado a generar una facturación basada en los precios de cada cita (validación).
function abrirModalFactura(id) {
    var url = "https://localhost:44361/Cita/FormularioFactura?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

/// Abre un modal para mostrar el resultado del total generado después de facturar.
function abrirModalTotal(id) {
    var url = "https://localhost:44361/Cita/FormularioTotal?id=" + id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}



/// Permite generar una lista de beneficiarios filtrados por cliente común.
function obtenerBeneficiarios() {

    var idCliente = $("#cliente").val();
    console.log(idCliente)

    if (idCliente == 0) {
        document.getElementById('beneficiario').options.length = 0;
        document.getElementById('beneficiario').options[0] = new Option("Seleccionar...", "0", true, false);
  
    } else {
        document.getElementById('beneficiario').options.length = 0;
        document.getElementById('beneficiario').options[0] = new Option("Seleccionar...", "0", true, false);
      

        $.get("https://localhost:44361/Beneficiario/ObtenerPorCliente?idCliente=" + idCliente, function (data) {
            console.log(data)
            if (data.length > 0) {

                for (var i = 0; i < data.length; i++) {
                    document.getElementById('beneficiario').options[i + 1] = new Option(data[i].Nombre, data[i].Id, false, false);
                }
            } else {
                document.getElementById('beneficiario').options[0] = new Option("Sin beneficiarios...", "0", true, false);
        
            }
            beneficiario = data;
        });
    }
}

/// Guarda un registro de cita en la base de datos.
function guardar() {
    var id = $('#idCita').val();
    var cliente = $('#cliente').val();
    var doctor = $('#doctor').val();
    var tratamiento = $('#tratamiento').val();
    var beneficiario = $('#beneficiario').val();
    var fecha = $('#datepicker').val();

    $.ajax({
        url: "https://localhost:44361/Cita/Guardar",
        data: { id: id, cliente: cliente, doctor: doctor, tratamiento: tratamiento, beneficiario: beneficiario, fecha: fecha },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert('Ocurrio un problema al guardar el registro de cita');
            }
        }
    });
}

/// Elimina un registro de cita en la base de datos.
function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {


        $.ajax({
            url: "https://localhost:44361/Cita/Eliminar",
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