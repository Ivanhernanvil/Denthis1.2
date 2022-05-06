using Denthis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denthis.Web.Models
{
    /// <summary>
    /// Obtiene y establece los datos establecidos en la clase cliente
    /// </summary>
    /// <returns></returns>
    public class ClienteModel
    {
        public Cliente Cliente { get; set; }
    }
}