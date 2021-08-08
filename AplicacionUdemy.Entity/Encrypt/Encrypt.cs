using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUdemy.Entity.Encrypt
{
    public class Encrypt
    {
        /// <summary>
        /// Encriptación de la contraseña
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GetSHA256(string info)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(info));

            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            
            return sb.ToString();
        }
    }
}
