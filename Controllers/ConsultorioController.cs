using Denthis.Core.Entities;
using Denthis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denthis.Web.Controllers
{

    /// <summary>
    /// Recibe y controla los eventos de entrada del consultorio
    /// </summary>
    public class ConsultorioController : Controller
    {


        // GET: Consultorio

        /// <summary>
        /// Abre el index y muestra el contenido
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            List<Consultorio> consultorios = Consultorio.ObtenerTodos();
            return View(consultorios);
        }

        public ActionResult Formulario(int id)
        {

            ConsultorioModel modelo = new ConsultorioModel();
            modelo.Consultorio = id != 0 ? Consultorio.ObtenerPorId(id) : new Consultorio();

            return PartialView(modelo);

        }

        /// <summary>
        /// Guarda un consultorio en la base de datos
        /// </summary>
        /// <param name="id">Identificador de el consultorio en la base de datos.</param>
        /// <param name="nombre">Nombre dado para la identificacion del consultorio en la base de datos</param>
        /// <param name="direccion">Direccion introducida del consultorio, localizacion/param>
        /// <param name="horario">Interbalo de horas representantes de la hora de abrir consultorio y cerrar consultorio.</param>
        /// <returns><see langword="true"/> si el registro fue guardado correctamente; de lo contrario, <see langword="false"/></returns>
        public ActionResult Guardar(int id, string nombre, string direccion, string horario)
        {
            bool resultado = false;

            try
            {
                resultado = Consultorio.Guardar(id, nombre, direccion, horario);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Elimina un consultorio de la base de datos
        /// </summary>
        /// <param name="id">Identificador de el beneficiario en la base de datos.</param>
        /// <returns></returns>
        public ActionResult Eliminar(int id)
        {
            bool resultado = false;
            try
            {
                resultado = Consultorio.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}