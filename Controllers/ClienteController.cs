using Denthis.Core.Entities;
using Denthis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denthis.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = Cliente.ObtenerTodos();
            return View(clientes);
        }

        public ActionResult Formulario(int id)
        {

            ClienteModel modelo = new ClienteModel();
            modelo.Cliente = id != 0 ? Cliente.ObtenerPorId(id) : new Cliente();

            return PartialView(modelo);

        }

        public ActionResult Guardar(int id, string nombre, string telefono, string correo, string contrasena)
        {
            bool resultado = false;

            try
            {
                resultado = Cliente.Guardar(id, nombre, telefono, correo, contrasena);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Eliminar(int id)
        {
            bool resultado = false;
            try
            {
                resultado = Cliente.Eliminar(id);
            }
            catch (Exception ex)
            {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}