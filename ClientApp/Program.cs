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


            //var result = client.Put(guid, content);
            var document = client.Post(docDto);
            document.Wait();
            var putResult = client.Put(document.Result.Id, content);
            putResult.Wait();
            // var getDocRes = client.GetDocument(document.Result.Id);
            var getContentRes = client.GetContent(document.Result.Id);
            getContentRes.Wait();
            //var r= getContentRes.Result;
            StreamReader sr = new StreamReader(getContentRes.Result.Stream);
            var str = sr.ReadToEnd();
        }
    }
}
