using AplicacionUdemy.Business;
using AplicacionUdemy.Entity.Encrypt;
using AplicacionUdemy.Entity.Parametros;
using AplicacionUdemy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                var clave_sinencriptar = oData.contrasena;
                oData.contrasena = clave;
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
                        //Envio de correo electrónico.
                        var _resultado = EnvioCorreo(paramss, clave_sinencriptar);

                        return Json(new { dt = rpt });
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

        public bool EnvioCorreo(RegistroEmpresaDTOEntity oData, string encriptar)
        {
            bool resultado = false;

            string url = string.Format("https://localhost:44354/ActivarCuenta/ActivarCuenta?ruc=" + oData.paramsEmpresa.ruc);
            string para = oData.paramsEmpresa.email;
            string asunto = "Activación de cuenta | Sistema de Facturación e Inventario";
            string mensaje = "<b> GRACIAS POR REGISTRARSE </b> <br /><br />" + "Estas son sus credenciales de acceso" + "<br /><br />" +
                "Usuario: " + oData.paramsEmpresa.usuario + "<br />" +
                "Contraseña: " + encriptar + "<br />" +
                "Cargo: " + oData.cargo + "<br /><br />" +
                "Para poder acceder al sistema debe primero activar la cuenta. Activela aquí <a href=\"" + url + "\"> aquí </a>" + "<br /><br />" +
                "Recuerde esto es un periodo de pruega por 15 días, para obtener una licencia escribenos al correo juan.castro.socla@gmail.com";

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("systemafactur@cnti365.com"); // cambiar el correo por el de ustedes
            correo.To.Add(para);
            correo.Subject = asunto;
            correo.Body = mensaje;
            correo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("mail.cnti365.com");// cambiar por su smtpHost.
            string scuentaCorreo = "systemafactur@cnti365.com"; // cambiar el correo por el de ustedes
            string sPassword = "M@46179378s";// cambiar el correo por el de ustedes.

            NetworkCredential credential = new NetworkCredential(scuentaCorreo, sPassword);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.Send(correo);
            resultado = true;

            return resultado;
        }

    }
}
