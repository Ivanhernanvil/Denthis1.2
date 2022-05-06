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
    /// Recibe y controla los eventos de entrada code la cita
    /// </summary>
    public class CitaController : Controller{

        public ActionResult Index()
        {
            List<Cita> citas = Cita.ObtenerTodas();
            return View(citas);
        }
        /// <summary>
        /// Abre y muestra el formulario
        /// </summary>
        /// <param name="id">Identificador para la base de datos</param>
        /// <returns>PartialView</returns>
        public ActionResult Formulario(int id)
        {

            CitaModel modelo = new CitaModel();
            modelo.Cita = id != 0 ? Cita.ObtenerPorId(id) : new Cita();
            modelo.Cliente = Cliente.ObtenerTodos();
            modelo.Doctor = Doctor.ObtenerTodos();
            modelo.Tratamiento = Tratamiento.ObtenerTodos();
            modelo.Beneficiario = Beneficiario.ObtenerTodos();
            return PartialView(modelo);

        }
        /// <summary>
        /// Abre y muestra el registro
        /// </summary>
        /// <param name="id">Identificador para la base de datos</param>
        /// <returns>PartialView</returns>
        public ActionResult Registro()
        {

            CitaModel modelo = new CitaModel();
            modelo.Cliente = Cliente.ObtenerTodos();
            modelo.Doctor = Doctor.ObtenerTodos();
            modelo.Tratamiento = Tratamiento.ObtenerTodos();
            modelo.Beneficiario = Beneficiario.ObtenerTodos();
         


            return View(modelo);
        }
        /// <summary>
        /// Abre y muestra la factura
        /// </summary>
        /// <returns>PartialView</returns>
        public ActionResult Factura()
        {

            List<Cliente> clientes = Cliente.ObtenerTodos();
            return View(clientes);
        }
        public ActionResult FormularioFactura(int id)
        {

            List<Cita> citas = Cita.ObtenerCitaPorCliente(id);

            return PartialView(citas);

        }

        /// <summary>
        /// Abre y muestra la factura total
        /// </summary>
        /// <param name="id">Identificador para la base de datos</param>
        /// <returns>PartialView</returns>
        public ActionResult FormularioTotal(int id)
        {

            List<Cita> citas = Cita.ObtenerFactura(id);

            return PartialView(citas);

        }
        /// <summary>
        /// Guarda los datos code la cita
        /// </summary>
        /// <param name="id">Identificador code la cita</param>
        /// <param name="cliente">Apellido paterno del ciudadano</param>
        /// <param name="doctor">Dentista que realizara el tratamiento</param>
        /// <param name="tratamiento">Accion medica a realizar</param>
        /// <param name="beneficiario">Persona que recibira el tratamiento</param>
        /// <param name="fecha">Dia establecido para la cita</param>
        /// <returns>Json</returns>
        public ActionResult Guardar(int id, int cliente, int doctor, int tratamiento, int beneficiario, string fecha)
        {
            bool resultado = false;

            try
            {
                resultado = Cita.Guardar( id,  cliente,  doctor,  tratamiento,  beneficiario,  fecha);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Elimina la cita
        /// </summary>
        /// <param name="id">Identificador para la base de datos del ciudadano</param>
        /// <returns>Json</returns>
        public ActionResult Eliminar(int id)
        {
            bool resultado = false;
            try
            {
                resultado = Cita.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }





    }
}