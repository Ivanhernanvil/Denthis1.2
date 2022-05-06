using Denthis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denthis.Web.Models {

    /// <summary>
    /// Obtiene y define los datos establecidos en la clase beneficiario
    /// </summary>
    /// <returns></returns>
    public class BeneficiarioModel
    {

        public Beneficiario Beneficiario { get; set; }
        public List<Cliente> Cliente { get; set; }
       
    }
}