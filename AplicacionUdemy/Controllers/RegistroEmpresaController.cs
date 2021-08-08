using AplicacionUdemy.Business;
using AplicacionUdemy.Entity.Encrypt;
using AplicacionUdemy.Entity.Parametros;
using AplicacionUdemy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
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

        [HttpPost]
        public ActionResult insertarEmpresa(HttpPostedFileBase file, RegistroEmpresaEntityParams oData) 
        {
            try
            {
                var clave = Encrypt.GetSHA256(oData.contrasena);
                var filename = "";
                if (file != null)
                {
                    string path = Server.MapPath("~/Content/img/img_empresas/"+ oData.ruc + "/");
                    string filePath = string.Empty;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(file.FileName);
                    file.SaveAs(filePath);
                    filename = file.FileName;
                }

                var paramss = new RegistroEmpresaDTOEntity();
                paramss.paramsEmpresa = oData;
                paramss.cantUser = 1;
                paramss.cargo = "superadmin";
                paramss.filename = filename;
                paramss.proyecto = "FACTUR";

                string token = "";
                var rpt = _empresaBusiness.insertarEmpresa(paramss, token);

                if (rpt.response == "Ok")
                {
                    rpt = _empresaBusiness.insertarUserAdminEmpresa(paramss, token);

                    if (rpt.response == "Ok")
                    {
                        return Json(new { dt = rpt });
                        //Envio de correo electrónico.
                    }
                }
                else
                {
                    return Json(new { dt = rpt });
                }

                return Json(new { dt = rpt});
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
