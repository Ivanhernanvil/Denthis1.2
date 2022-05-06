using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denthis.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Abre el index y muestra el contenido
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

       

    }
}