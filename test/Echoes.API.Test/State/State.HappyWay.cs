using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Echoes.API.Test.State
{
    [TestFixture]
    public class State_HappyWay
    {
        private string _id;
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test, Order(1)]
        public async Task Return_Empty_Array()
        {
            // Act
            var response = await _client.GetAsync("/State");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("[]",responseString);
        }

        [Test, Order(2)]
        public async Task Insert_Model_And_Return_Self()
        {
            var model = new {
                code = "CE",
                name = "CEARÁ"
            };

            var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            // Act
            var response = await _client.PostAsync("/State", body);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseBody = new { id="", code = "", name = "" };
            responseBody = JsonConvert.DeserializeAnonymousType(responseString, responseBody);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            _id = responseBody.id;
            Assert.AreEqual("CE", responseBody.code);
            Assert.AreEqual("CEARÁ", responseBody.name);
        }

        [Test, Order(3)]
        public void Delete_Model_And_Return_Not_Content()
        {
            // Act
            var response = _client.DeleteAsync("/State/"+_id).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}