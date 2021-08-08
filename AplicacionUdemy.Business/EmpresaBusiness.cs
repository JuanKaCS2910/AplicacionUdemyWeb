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
    public class EmpresaBusiness
    {
        private Client _client;

        public EmpresaBusiness()
        {
            _client = new Client();
        }

        public ResponseRegistroEmpresa validarRegistro(RegistroEmpresaEntity _entidad, string valor)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(_client.Post<RegistroEmpresaEntity>("RegistroEmpresa/validarRegistro", _entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResponseRegistroEmpresa insertarEmpresa(RegistroEmpresaDTOEntity _entidad, string valor)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(_client.Post<RegistroEmpresaDTOEntity>("RegistroEmpresa/insertarEmpresa", _entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResponseRegistroEmpresa insertarUserAdminEmpresa(RegistroEmpresaDTOEntity _entidad, string valor)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(_client.Post<RegistroEmpresaDTOEntity>("RegistroEmpresa/insertarUserAdminEmpresa", _entidad, valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        

    }
}
