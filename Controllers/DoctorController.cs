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
    public class DoctorController : Controller
    {
        // GET: Doctor
        /// <summary>
        /// Abre el index y muestra el contenido
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            List<Doctor> doctores = Doctor.ObtenerTodos();
            return View(doctores);
        }

        public ActionResult Formulario(int id)
        {

            DoctorModel modelo = new DoctorModel();
            modelo.Doctor = id != 0 ? Doctor.ObtenerPorId(id) : new Doctor();
            modelo.Consultorio = Consultorio.ObtenerTodos();
            return PartialView(modelo);

        }
        /// <summary>
        /// Guarda un consultorio en la base de datos
        /// </summary>
        /// <param name="id">Identificador de el consultorio en la base de datos.</param>
        /// <param name="nombre">Nombre dado para la identificacion del consultorio en la base de datos</param>
        /// <param name="especialidad">Area en la cual se especifica el doctor/param>
        /// <param name="consultorio">Identificador del consultorio donde el doctor trabaja.</param>
        /// <returns><see langword="true"/> si el registro fue guardado correctamente; de lo contrario, <see langword="false"/></returns>
        public ActionResult Guardar(int id, string nombre, string especialidad, int consultorio)
        {
            bool resultado = false;

            try
            {
                resultado = Doctor.Guardar(id, nombre, especialidad, consultorio);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Elimina un doctor de la base de datos
        /// </summary>
        /// <param name="id">Identificador del doctor en la base de datos.</param>
        /// <returns></returns>
        public ActionResult Eliminar(int id)
        {
            bool resultado = false;
            try
            {
                resultado = Doctor.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



    }
}