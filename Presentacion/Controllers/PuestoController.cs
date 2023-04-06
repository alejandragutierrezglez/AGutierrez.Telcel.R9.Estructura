using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class PuestoController : Controller
    {
        // GET: Puesto
        public ActionResult GetAll()
        {
            Negocio.Puesto puesto = new Negocio.Puesto();
            Negocio.Result resultPuesto = Negocio.Puesto.GetAllEF();

            if (resultPuesto.Correct)
            {
                puesto.Puestos = resultPuesto.Objects;
                return View(puesto);
            }
            else
            {
                return View(puesto);
            }
        }
    }
}