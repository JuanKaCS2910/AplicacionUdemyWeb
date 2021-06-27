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
    public class MonedaBusiness
    {
        private Client _client;

        public MonedaBusiness()
        {
            _client = new Client();
        }

        public List<ResponseMoneda> ListarMonedas(RegistroEmpresaEntity _entidad,string valor) 
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseMoneda>>(_client.Post<RegistroEmpresaEntity>("RegistroEmpresa/listarMonedas",_entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
