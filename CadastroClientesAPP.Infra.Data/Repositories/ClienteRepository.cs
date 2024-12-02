using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Infra.Data.Contexts;
using CadastroClientesAPP.Domain.Interfaces.IRepositories;


namespace CadastroClientesAPP.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _context.Clientes.ToListAsync();

        public async Task<Cliente> GetByIdAsync(Guid id) => await _context.Clientes.FindAsync(id);

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var cliente = await GetByIdAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
