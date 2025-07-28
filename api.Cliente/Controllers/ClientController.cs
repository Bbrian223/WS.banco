using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Cliente.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        public readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var result = await _clientService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener los datos de los clientes");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var result = await _clientService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener los datos del cliente: " + id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetClient(Client client) 
        {
            try
            {
                var result = await _clientService.SetAsync(client);

                if (!result) 
                    throw new Exception();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error al cargar el cliente");
            }

        }
    }
}
