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
    public class ImpuestoBusiness
    {
        private Client _client;

        public ImpuestoBusiness()
        {
            _client = new Client();
        }

        public List<ResponseImpuesto> ListaImpuesto(RegistroEmpresaEntity _entidad,string valor) 
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseImpuesto>>(_client.Post<RegistroEmpresaEntity>("RegistroEmpresa/listarImpuestos",_entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
