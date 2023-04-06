using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            Negocio.Empleado empleado = new Negocio.Empleado();
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            Negocio.Result resultEmpleado = Negocio.Empleado.GetAllEF(empleado);


            if (resultEmpleado.Correct)
            {
                empleado.Empleados = resultEmpleado.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult GetAll(Negocio.Empleado empleado)
        {

            Negocio.Result result = new Negocio.Result();
            result = Negocio.Empleado.GetAllEF(empleado);

            if (result.Correct)

            {
                empleado.Empleados = result.Objects;

                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        public ActionResult Delete(int EmpleadoID)
        {
            Negocio.Result result = Negocio.Empleado.DeleteEF(EmpleadoID);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el empleado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro del empleado seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }

        [HttpGet]
        public ActionResult Form(int? EmpleadoID)
        {
            Negocio.Empleado empleado = new Negocio.Empleado();

            if (EmpleadoID == null)
            {
                //add //formulario vacio
                return View(empleado);
            }
            return View(empleado);
        }



        [HttpPost]
        public ActionResult Form(Negocio.Empleado empleado)
        {
            Negocio.Result result = Negocio.Empleado.AddEF(empleado);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha agregado el empleado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido agregar el empleado" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
    }
}