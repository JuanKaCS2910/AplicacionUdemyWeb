using AplicacionUdemy.Business;
using AplicacionUdemy.Entity.Parametros;
using AplicacionUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionUdemy.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private PaisBusiness _paisBusiness;

        public RegistroEmpresaController()
        {
            model = new modelList();
            _paisBusiness = new PaisBusiness();
        }

        // GET: RegistroEmpresa
        public ActionResult RegistroEmpresa(RegistroEmpresaEntity paramss)
        {
            string token = "";
            model.listPais = _paisBusiness.ListarPaises(paramss,token);
            return View(model);
        }

        
    }
}
