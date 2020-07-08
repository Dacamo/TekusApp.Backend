using System.Net;
using System.Threading.Tasks;
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
    }
}
