using IntecoAG.XafExt.Ecm.WebStore;
using System;
using System.IO;
using System.Net.Http;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://localhost:5001";
            System.Net.Http.HttpClient httpClient = new HttpClient();
            var client = new Client(baseUrl, httpClient);
            System.IO.Stream body = new MemoryStream();
            //var createdDoc = client.RootAsync("a1", (int?)10, body);
            var createdDoc = client.Post(null);
            createdDoc.Wait();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
