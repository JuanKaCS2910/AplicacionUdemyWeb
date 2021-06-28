using AplicacionUdemy.Clients;
using AplicacionUdemy.Entity.Parametros;
using AplicacionUdemy.Entity.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUdemy.Business
{
    public class PorcentajeBusiness
    {
        private Client _client;

        public PorcentajeBusiness()
        {
            _client = new Client();
        }

        public List<ResponsePorcentaje> ListaPorcentaje(RegistroEmpresaEntity _entidad,string valor) 
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePorcentaje>>(_client.Post<RegistroEmpresaEntity>("RegistroEmpresa/listarPorcentajes",_entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
