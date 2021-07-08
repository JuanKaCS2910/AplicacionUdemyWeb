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
        private MonedaBusiness _monedaBusiness;
        private ImpuestoBusiness _impuestoBusiness;
        private PorcentajeBusiness _porcentajeBusiness;
        private EmpresaBusiness _empresaBusiness;

        public RegistroEmpresaController()
        {
            model = new modelList();
            _paisBusiness = new PaisBusiness();
            _monedaBusiness = new MonedaBusiness();
            _impuestoBusiness = new ImpuestoBusiness();
            _porcentajeBusiness = new PorcentajeBusiness();
            _empresaBusiness = new EmpresaBusiness();
        }

        // GET: RegistroEmpresa
        public ActionResult RegistroEmpresa(RegistroEmpresaEntity paramss)
        {
            string token = "";
            model.listPais = _paisBusiness.ListarPaises(paramss, token);
            model.listMoneda = _monedaBusiness.ListarMonedas(paramss, token);
            model.listImpuesto = _impuestoBusiness.ListaImpuesto(paramss, token);
            model.listPorcentaje = _porcentajeBusiness.ListaPorcentaje(paramss, token);
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult validarRegistro(RegistroEmpresaEntity paramss)
        {
            var respuesta = _empresaBusiness.validarRegistro(paramss,"");
            return Json(new { dt = respuesta });
        }


    }
}
