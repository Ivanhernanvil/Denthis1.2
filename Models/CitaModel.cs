using Denthis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Denthis.Web.Models
{

    /// <summary>
    /// Obtiene y establece los datos establecidos en la clase cita
    /// </summary>
    /// <returns></returns>
    public class CitaModel
    {

        public Cita Cita { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<Cliente> Cliente { get; set; }
        public List<Tratamiento> Tratamiento { get; set; }
        public List<Beneficiario> Beneficiario { get; set; }

    }
}