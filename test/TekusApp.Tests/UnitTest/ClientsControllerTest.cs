using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TekusApp.Commands;
using TekusApp.Controllers;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;
using TekusApp.Mappings;
using Xunit;

namespace TekusApp.Tests.UnitTest
{
    public class ClientsControllerTest
    {

        //Mocks
        Mock<IClientBehavior> mockRepo = new Mock<IClientBehavior>();
        Mock<IMapper> mockMapper = new Mock<IMapper>();

        [Fact]
        public async Task Get_Clients_Return_All_Clients()
        {
            
            //Arrange
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

        [Fact]
        public async Task Get_Clients_Returns_EmptyList()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Client> ());
            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Get_ClientById_Returns_Client()
        {
            //Arrange
            var client = new Client()
            {
                Id = 2,
                Email = "correo1@hotmail.com",
                Name = "Nombre 2",
                NIT = "1234"
            };

            mockRepo.Setup(repo => repo.GetByIdAsync(2))
                .ReturnsAsync(client);

            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.GetByIdAsync(2);

            // Assert
            Assert.Equal(client.Id, result.Value.Id);
            Assert.Equal(client.Name, result.Value.Name);
            Assert.Equal(client.Email, result.Value.Email);
        }

        [Fact]
        public async Task Get_ClientById_Returns_NotFound()
        {
            //Arrange
            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.GetByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
           
        }
 
        [Fact]
        public async Task Count_clients_Return_zero()
        {

            //Arrange
            mockRepo.Setup(repo => repo.CountAsync())
                .ReturnsAsync(0);

            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.CountAsync();

            // Assert
            Assert.Equal(0, result.Value);
            

        }

        [Fact]
        public async Task Count_clients_Return_Two()
        {

            //Arrange
            mockRepo.Setup(repo => repo.CountAsync())
                .ReturnsAsync(2);

            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.CountAsync();

            // Assert
            Assert.Equal(2, result.Value);

        }

        [Fact]
        public async Task Remove_NotExistingClient_ReturnsNotFound()
        {
            // Arrange
            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);
            // Act
            var response = await controller.DeleteAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Remove_ExistingClient_ReturnsNoContent()
        {
            // Arrange

            var client = new Client()
            {
                Id = 2,
                Email = "correo1@hotmail.com",
                Name = "Nombre 2",
                NIT = "1234"
            };

            mockRepo.Setup(repo => repo.GetByIdAsync(2))
               .ReturnsAsync(client);


            var controller = new ClientsController(mockRepo.Object, mockMapper.Object);
            // Act
            var response = await controller.DeleteAsync(2);

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

    }
}
