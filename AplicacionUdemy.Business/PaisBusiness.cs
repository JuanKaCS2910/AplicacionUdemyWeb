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
    public class PaisBusiness
    {
        private Client _client;

        public PaisBusiness()
        {
            _client = new Client();
        }

        public List<ResponsePais> ListarPaises(RegistroEmpresaEntity _entidad,string valor) 
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePais>>(_client.Post<RegistroEmpresaEntity>("RegistroEmpresa/listarPaises",_entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
