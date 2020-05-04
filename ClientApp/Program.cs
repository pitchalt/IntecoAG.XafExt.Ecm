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
            string baseUrl = "https://localhost:44358";
            System.Net.Http.HttpClient httpClient = new HttpClient();

            var client = new Client(baseUrl, httpClient);
            FileStream content = new FileStream(@"C:\Projects\data.txt", FileMode.Open);

            var doc = new DocDTO() { Cmisaction = "create" };

            //var createdDoc = client.Post(doc);
            //createdDoc.Result;


            var createdDoc = client.Post(Guid.NewGuid(), doc);
            //var contentDoc = client.GetContent(Guid.NewGuid());
            //var result = client.GetDocument(Guid.NewGuid());
            //result.Wait();

            var result = client.Put(Guid.NewGuid(), content);
            result.Wait();
            createdDoc.Wait();
            Console.ReadKey();
        }
    }
}
