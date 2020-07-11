using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Commands;
using TekusApp.Domain.Models;
using TekusApp.Tests.IntegrationTest.utils;
using Xunit;

namespace TekusApp.Tests.IntegrationTest
{
    public class ClientsControllerTest: WebTest
    {
        [Fact]
        public async Task Get_Clients_Returns_EmptyList()
        {
            //Arrange
            //Act
            var response = await _client.GetAsync("/api/Clients");
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("[]", content);
        }

        [Fact]
        public async Task Get_ClientById_Returns_NotFound()
        {
            //preparar
            var response = await _client.GetAsync("/api/clients/1");


            // Validar
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
