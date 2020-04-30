using IntecoAG.XafExt.Ecm.WebStore;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace IntecoAG.XafExt.Ecm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string baseUrl = "https://localhost:44358";
            System.Net.Http.HttpClient httpClient = new HttpClient();
            var client = new Client(baseUrl, httpClient);
            FileStream content = new FileStream(@"C:\Projects\data.txt", FileMode.Open);

            var createdDoc =  client.Put(Guid.Empty, content);
            createdDoc.Wait();
            Assert.Null(createdDoc);
           
            Assert.Equal(1,1);
        }
    }
}