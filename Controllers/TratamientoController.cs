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
    /// Recibe y controla los eventos de entrada 
    /// </summary>
    public class TratamientoController : Controller
    {
        // GET: Tratamiento
        /// <summary>
        /// Abre el index y muestra el contenido
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            List<Tratamiento> tratamientos = Tratamiento.ObtenerTodos();
            return View(tratamientos);
        }
        /// <summary>
        /// Abre y muestra el formulario
        /// </summary>
        /// <param name="id">Identificador para la base de datos</param>
        /// <returns>PartialView</returns>
        public ActionResult Formulario(int id)
        {

            TratamientoModel modelo = new TratamientoModel();
            modelo.Tratamiento = id != 0 ? Tratamiento.ObtenerPorId(id) : new Tratamiento();

            return PartialView(modelo);
        }
        /// <summary>
        /// Guarda un tratamiento en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la base de datos</param>
        /// <param name="nombre">Nombre del tratamiento</param>
        /// <param name="precio">cuota asignada al tratamiento</param>
        public ActionResult Guardar(int id, string nombre, double precio)
        {
            bool resultado = false;

            try
            {
                resultado = Tratamiento.Guardar(id, nombre, precio );
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
                resultado = Tratamiento.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}