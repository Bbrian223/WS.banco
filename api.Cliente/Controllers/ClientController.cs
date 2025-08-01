using Application.Responce;
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
            ApiResponce<List<Client>> responce = new ApiResponce<List<Client>>();

            try
            {
                var result = await _clientService.GetAllAsync();
                responce.Success(result);
            }
            catch (Exception)
            {
                responce.Error("Error al obtener los clientes");
            }

            return Ok(responce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            ApiResponce<Client> responce = new ApiResponce<Client>();

            try
            {
                var result = await _clientService.GetByIdAsync(id);
                responce.Success(result);
            }
            catch (Exception)
            {
                responce.Error($"Error al obtnener los datos del cliente: {id}");
            }

            return Ok(responce);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client client) 
        {
            ApiResponce<bool> responce = new ApiResponce<bool>();

            try
            {
                var result = await _clientService.AddAsync(client);

                if (!result) 
                    throw new Exception();

                responce.Success(result);
            }
            catch (Exception)
            {
                responce.Error("Error al generar crear el nuevo cliente");
            }

            return Ok(responce);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            ApiResponce<bool> responce = new ApiResponce<bool>();

            try
            {
                var result = await _clientService.UpdateAsync(client);

                if (!result)
                    throw new Exception();

                responce.Success(result);
            }
            catch (Exception)
            {
                responce.Error($"Error al actualizar los datos del cliente: {client.id}");
            }

            return Ok(responce);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveClient(int id)
        {
            ApiResponce<bool> responce = new ApiResponce<bool>();

            try
            {
                var result = await _clientService.RemoveByIdAsync(id);

                if (!result)
                    throw new Exception();

                responce.Success(result);
            }
            catch (Exception)
            {
                responce.Error($"Error al dar de baja al cliente: {id}");
            }

            return Ok(responce);
        }

    }
}
