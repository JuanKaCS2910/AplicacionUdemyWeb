using AplicacionUdemy.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionUdemy.Models
{
    public class modelList
    {

        public List<ResponsePais> listPais { get; set; }
        public List<ResponseMoneda> listMoneda { get; set; }
        public List<ResponseImpuesto> listImpuesto { get; set; }
        public List<ResponsePorcentaje> listPorcentaje { get; set; }

    }
}