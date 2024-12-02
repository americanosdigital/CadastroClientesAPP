using Microsoft.AspNetCore.Mvc;
using CadastroClientesAPP.Domain.Entities;
using CadastroClientesAPP.Domain.Interfaces.IServices;
using CadastroClientesAPP.Domain.Services;
using CadastroClientesAPP.Infra.Data.Contexts;


namespace CadastroClientesAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                return Ok(clientes);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,
               new
               {
                   mensagem = "Falha ao Obter Todos Cliente: " + e.Message
               });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);
                return Ok(cliente);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,
               new
               {
                   mensagem = "Falha ao Obter Cliente: " + e.Message
               });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            try
            {
                await _clienteService.AddAsync(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,
               new
               {
                   mensagem = "Falha ao Cadastrar Cliente: " + e.Message
               });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Cliente cliente)
        {
            try
            {
                await _clienteService.UpdateAsync(cliente);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,
               new
               {
                   mensagem = "Falha ao Atualizar Cliente: " + e.Message
               });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _clienteService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,
               new
               {
                   mensagem = "Falha ao Deletar Cliente: " + e.Message
               });
            }
        }
    }
}
