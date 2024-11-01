
using Microsoft.AspNetCore.Mvc;
using SrbComercialInfrastructure.Repository;
using SrbComercialDomain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SrbComercialApplication.Controllers.Clients;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public ClientController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

     [HttpGet(Name = "GetClient")/*, Authorize*/]
    public IActionResult Index()
    {
        var clients = _unitOfWork.Client.GetAll();
        return Ok(clients);
    }


    [HttpPost(Name = "CreateClient")/*, Authorize*/]
    public IActionResult Create(Client client)
    {
        if ( client == null)
        {
            return BadRequest("Client is null.");
        }

        // Validação simples
        if (string.IsNullOrEmpty( client.Name))
        {
            return BadRequest("Client name is required.");
        }

        _unitOfWork.Client.Add( client);
        _unitOfWork.Save();

        return CreatedAtAction(nameof(Index), new { id =  client.Id },  client);
    }

    [HttpPut("{id}",Name = "UpdateClient")/*, Authorize*/]
    public IActionResult Update(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest("Client ID mismatch");
        }

        try
        {
            // Chama o método de atualização no repositório de produto
            _unitOfWork.Client.Update(client);

            // Salva as alterações
            _unitOfWork.Save();

            return Ok("Client updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
	
    [HttpDelete("{id}",Name = "DeleteClient")/*, Authorize*/]
    public IActionResult Delete(int id)
        {
            var client = _unitOfWork.Client.Get(p => p.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _unitOfWork.Client.Remove(client);
            _unitOfWork.Save();

            return NoContent();
        }
}