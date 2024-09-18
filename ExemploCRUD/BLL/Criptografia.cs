using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace ExemploCRUD.BLL
{
    public class Criptografia
    {
        public string RetornaMD5(string texto)
        {
            //Codificador para converter texto em byte.
            UnicodeEncoding UE = new UnicodeEncoding();

            MD5 md5 = new MD5CryptoServiceProvider();
            //SHA1 sha1 = new SHA1CryptoServiceProvider();

            string textoCriptografado = "";
            byte[] HashValue, BytesTexto;

            BytesTexto = UE.GetBytes(texto);

            /*
            Função de dispersão criptográfica ou função hash 
            criptográfica é uma função hash considerada 
            praticamente impossível de inverter, isto é, 
            de recriar o valor de entrada utilizando 
            somente o valor de dispersão. 
            */

            HashValue = md5.ComputeHash(BytesTexto);

            foreach (byte b in HashValue)
            {
                textoCriptografado += String.Format("{0:x2}", b); 
                //X->Hexadecimal 2-> dois caracteres
            }

            return textoCriptografado;
        }
    }
}
