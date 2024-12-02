using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Bogus;
using CadastroClientesAPP.API.Controllers;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;


namespace CadastroClientesAPI.Tests
{
    public class ClienteControllerTests
    {
        [Fact]
        public async Task GetAll_Should_Return_OkResult_With_Clientes()
        {
            // Arrange
            var mockService = new Mock<IClienteService>();
            mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<Cliente>
        {
            new Cliente("João", "Silva", 30, "Rua A"),
            new Cliente("Maria", "Oliveira", 25, "Rua B")
        });
            var controller = new ClienteController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var clientes = Assert.IsType<List<Cliente>>(okResult.Value);
            Assert.Equal(2, clientes.Count);
        }

        [Fact]
        public async Task Add_Should_Call_Service_Add()
        {
            // Arrange
            var mockService = new Mock<IClienteService>();
            var cliente = new Cliente("João", "Silva", 30, "Rua A");
            var controller = new ClienteController(mockService.Object);

            // Act
            await controller.Add(cliente);

            // Assert
            mockService.Verify(service => service.AddAsync(cliente), Times.Once);
        }
    }
}
