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
            string baseUrl = "http://localhost:5000";
            System.Net.Http.HttpClient httpClient = new HttpClient();

            var client = new Client(baseUrl, httpClient);
            FileStream content = new FileStream(@"C:\Projects\data.txt", FileMode.Open);

            var docDto = new DocDTO() { Cmisaction = "create" };

            var guid = Guid.Parse("06ace423-001a-42a8-9cfe-8c63d4068f9a");
            //var result = client.Put(guid, content);
            var document = client.Post(docDto);
            // document.Wait();
            var putResult = client.Put(document.Result.Id, content);
            // var getDocRes = client.GetDocument(document.Result.Id);
            var getContentRes = client.GetContent(document.Result.Id);
            //var r= getContentRes.Result;
            getContentRes.Wait();
            getContentRes.Result.Stream.CopyTo(new FileStream(@"C:\Projects\lizon.txt", FileMode.OpenOrCreate));
            //result.Wait();
        }
    }
}
