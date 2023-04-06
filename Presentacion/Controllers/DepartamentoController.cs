using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult GetAll()
        {
            Negocio.Departamento departamento = new Negocio.Departamento();
            Negocio.Result resultDepartamento = Negocio.Departamento.GetAllEF();

            if (resultDepartamento.Correct)
            {
                departamento.Departamentos = resultDepartamento.Objects;
                return View(departamento);
            }
            else
            {
                return View(departamento);
            }
        }
    }
}