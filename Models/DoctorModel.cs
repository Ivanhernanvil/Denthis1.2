using Denthis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denthis.Web.Models
{

    /// <summary>
    /// Obtiene y establece los datos establecidos en la clase doctor
    /// </summary>
    /// <returns></returns>
    public class DoctorModel{

        public Doctor Doctor { get ;   set; }
        public List<Consultorio> Consultorio { get; set; }
    }
}