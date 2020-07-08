using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekusApp.Controllers;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;
using Xunit;

namespace TekusApp.Tests.UnitTest
{
    public class ClientsControllerTest
    {

        [Fact]
        public async Task Get_Clients_Return_All_Clients()
        {
            //Arrange
            var mockRepo = new Mock<IClientBehavior>();
            var mockMapper = new Mock<IMapper>();

            var clients = new List<Client>();
            clients.Add(new Client()
            {
                Id = 1,
                Email = "correo1@hotmail.com",
                Name = "Nombre",
                NIT = "123"
            });
            clients.Add(new Client()
            {
                Id = 2,
                Email = "correo1@hotmail.com",
                Name = "Nombre 2",
                NIT = "1234"
            });
            ;

            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(clients);
            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());

        }
    }
}
