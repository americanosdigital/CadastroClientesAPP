using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Domain.Interfaces.IRepositories;
using CadastroClientesAPP.Domain.Interfaces.IServices;


namespace CadastroClientesAPP.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");

            return cliente;
        }

        public async Task AddAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            var existingCliente = await _clienteRepository.GetByIdAsync(cliente.Id);

            if (existingCliente == null)
                throw new KeyNotFoundException($"Cliente com ID {cliente.Id} não encontrado para atualização.");

            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado para exclusão.");

            await _clienteRepository.DeleteAsync(id);
        }
    }
}