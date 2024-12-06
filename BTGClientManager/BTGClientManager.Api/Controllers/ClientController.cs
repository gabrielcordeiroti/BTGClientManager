using BTGClientManager.Application.Interfaces;
using BTGClientManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BTGClientManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clienteService;

        public ClientController(IClientService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Client cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteService.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Client cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteService.Update(cliente, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCliente = _clienteService.GetById(id);
            if (existingCliente == null)
                return NotFound();

            await _clienteService.Delete(id);
            return NoContent();
        }
    }
}
