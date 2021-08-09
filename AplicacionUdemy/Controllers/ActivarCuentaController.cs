using AplicacionUdemy.Business;
using AplicacionUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace AplicacionUdemy.Controllers
{
    public class ActivarCuentaController : Controller
    {
        private modelList model;
        private EmpresaBusiness _empresaBusiness;

        public ActivarCuentaController()
        {
            model = new modelList();
            _empresaBusiness = new EmpresaBusiness();
        }

        // GET: ActivarCuenta
        public ActionResult ActivarCuenta(string ruc)
        {
            string token = "";
            model.msjActivarCuenta = _empresaBusiness.activarCuenta(ruc, token);
            return View(model);
        }
    }
}