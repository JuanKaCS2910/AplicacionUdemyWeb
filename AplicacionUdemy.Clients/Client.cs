using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUdemy.Clients
{
    public class Client
    {
        private string URLService = ConfigurationManager.AppSettings["URLService"];

        public string Post<T>(string Method, T Object, string accessToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                    client.BaseAddress = new Uri(URLService);
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(accessToken))

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


                    string jsonparameters = JsonConvert.SerializeObject(Object);

                    var content = new StringContent(jsonparameters, System.Text.Encoding.UTF8, "application/json");

                    var result = client.PostAsync(Method, content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;

                        return resultContent;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public T Get<T>(string MethodWithParameters, string accessToken = null)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                client.BaseAddress = new Uri(URLService);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(accessToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var result = client.GetAsync(MethodWithParameters).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(resultContent);
                }
            }
            return default(T);
        }

        public byte[] Get(string MethodWithParameters)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLService);

                var result = client.GetAsync(MethodWithParameters).Result;
                if (result.IsSuccessStatusCode)
                {
                    byte[] bytes = result.Content.ReadAsByteArrayAsync().Result;
                    return bytes;
                }
            }
            return null;
        }



    }
}
