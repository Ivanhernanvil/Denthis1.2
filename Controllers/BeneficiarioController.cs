using Denthis.Core.Entities;
using Denthis.Core.Enum;
using Denthis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denthis.Web.Controllers
{
    public class BeneficiarioController : Controller
    {
        /// <summary>
        /// Recibe y controla los eventos de entrada Beneficiario
        /// </summary>
        public ActionResult Index()
        {
            List<Beneficiario> beneficiarios = Beneficiario.ObtenerTodos();
            return View(beneficiarios);
        }
     
        public ActionResult Formulario(int id)
        {
            
            BeneficiarioModel modelo = new BeneficiarioModel();
            modelo.Beneficiario = id != 0 ? Beneficiario.ObtenerPorId(id) : new Beneficiario();
            modelo.Cliente = Cliente.ObtenerTodos();
            return PartialView(modelo);

        }

        public ActionResult ObtenerPorCliente(int idCliente)
        {
            List<Beneficiario> beneficiarios = Beneficiario.ObtenerPorCliente(idCliente);
            return Json(beneficiarios, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Guarda los parametros en la base de datos
        /// </summary>
        /// <param name="id">Identificador de el beneficiario en la base de datos.</param>
        /// <param name="nombre">Nombre dado para la identificacion de el beneficiario en la base de datos</param>
        /// <param name="apellidoPaterno">Identidad del appelido paterno en la base de datos</param>
        /// <param name="apellidoMaterno">Identidad del appelido materno en la base de datos</param>
        /// <param name="edad">edad del beneficiario en la base de datos</param>
        /// <param name="sexo">genero del beneficiario en la base de datos</param>
        /// <param name="cliente">Identidad de la persona que sera el beneficiario en la base de datos</param>
        /// <returns><see langword="true"/> si el registro fue guardado correctamente; de lo contrario, <see langword="false"/></returns>
        public ActionResult Guardar(int id, string nombre, string apellidoPaterno, string apellidoMaterno, int edad, string sexo, int cliente)
        {
            bool resultado = false;

            try
            {
                resultado = Beneficiario.Guardar(id, nombre, apellidoPaterno, apellidoMaterno, edad, sexo, cliente);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Elimina una ciudad de la base de datos
        /// </summary>
        /// <param name="id">Identificador de el beneficiario en la base de datos.</param>
        /// <returns></returns>
        public ActionResult Eliminar(int id)
        {
            bool resultado = false;
            try
            {
                resultado = Beneficiario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


    }
}