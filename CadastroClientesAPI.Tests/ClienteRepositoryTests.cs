using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using Bogus;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Infra.Data.Repositories;
using CadastroClientesAPP.Infra.Data.Contexts;


namespace CadastroClientesAPI.Tests
{
    public class ClienteRepositoryTests
    {
        private DataContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"TestDatabase_{Guid.NewGuid()}") 
                .Options;

            return new DataContext(options);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Cliente()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ClienteRepository(context);
            var cliente = new Cliente("João", "Silva", 30, "Rua A");

            // Act
            await repository.AddAsync(cliente);

            // Assert
            var result = await context.Clientes.FirstOrDefaultAsync(c => c.Name == "João");
            Assert.NotNull(result);
            Assert.Equal("João", result.Name);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Clientes()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Clientes.RemoveRange(context.Clientes); // Remove todos os registros existentes
            await context.SaveChangesAsync();

            var repository = new ClienteRepository(context);
            context.Clientes.AddRange(
                new Cliente("João", "Silva", 30, "Rua A"),
                new Cliente("Maria", "Oliveira", 25, "Rua B")
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
