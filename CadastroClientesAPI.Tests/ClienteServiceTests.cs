using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Bogus;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Domain.Interfaces.IRepositories;
using CadastroClientesAPP.Domain.Services;

namespace CadastroClientesAPI.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public async Task AddAsync_Should_Call_Repository_Add()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            var cliente = new Cliente("João", "Silva", 30, "Rua A");
            var service = new ClienteService(mockRepository.Object);

            // Act
            await service.AddAsync(cliente);

            // Assert
            // Verifica se o método foi chamado com um cliente específico
            mockRepository.Verify(repo => repo.AddAsync(
                It.Is<Cliente>(c => c.Name == "João" && c.Lastname == "Silva" && c.Age == 30)
            ), Times.Once);
        }



        [Fact]
        public async Task GetAllAsync_Should_Return_All_Clientes()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Cliente>
        {
            new Cliente("João", "Silva", 30, "Rua A"),
            new Cliente("Maria", "Oliveira", 25, "Rua B")
        });
            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
