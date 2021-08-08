using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUdemy.Entity.Parametros
{
    public class RegistroEmpresaEntity
    {
        public string razonSocial { get; set; }
        public string ruc { get; set; }
        public string email { get; set; }

    }

    public class RegistroEmpresaDTOEntity
    {
        public RegistroEmpresaEntityParams paramsEmpresa { get; set; }
        public int cantUser { get; set; }
        public string cargo { get; set; }
        public string  filename { get; set; }
        public string proyecto { get; set; }
    }
    public class RegistroEmpresaEntityParams
    {
        public string razonSocial { get; set; }
        public string ruc { get; set; }
        public string email { get; set; }
        public int idPais { get; set; }
        public int idMoneda { get; set; }
        public string direccion { get; set; }
        public int idImpuesto { get; set; }
        public int idPorcentaje { get; set; }
        public int vendeImpuesto { get; set; }

        public string username { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
