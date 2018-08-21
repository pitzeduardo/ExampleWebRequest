using ExampleWebRequest.Models;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ExampleWebRequest
{
    public class WebRequestService
    {
        public Cidade GetCEP(string cep)
        {
            var cidadeReturn = new Cidade();

            WebRequest requestCEP = WebRequest.Create(ReturnURI(cep));
            requestCEP.Credentials = CredentialCache.DefaultCredentials;

            WebResponse responseCEP = requestCEP.GetResponse();

            Stream responseStream = responseCEP.GetResponseStream();
            StreamReader readerStream = new StreamReader(responseStream);

            string jsonResponse = readerStream.ReadToEnd();
            cidadeReturn = JsonConvert.DeserializeObject<Cidade>(jsonResponse);

            readerStream.Close();
            responseCEP.Close();

            return cidadeReturn;
        }

        #region URI ViaCEP

        private string ReturnURI(string cep)
        {
            return "http://www.viacep.com.br/ws/" + cep + "/json/";
        }

        #endregion 

    }
}
