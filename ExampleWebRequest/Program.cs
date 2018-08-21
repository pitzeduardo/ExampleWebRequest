using System;

namespace ExampleWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input CEP: ");
            var cep = Console.ReadLine();

            var cepService = new WebRequestService();
            var cidadeReturn = cepService.GetCEP(cep);

            Console.WriteLine(string.Format("Name of City: {0}", cidadeReturn.localidade));
            Console.ReadKey();
        }
    }
}
