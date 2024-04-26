using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController:ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Client>>>> GetAll()
    {
        var response = new Response<List<ClientDto>>
        {
            Data = await _clientService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ClientDto>>> Post([FromBody] ClientDto clientDto)
    {
        var response = new Response<ClientDto>
        {
            Data = await _clientService.SaveAsync(clientDto)
        };
        return Created($"/api/[controller]/{clientDto.idClient}", response);
    }
    
    [HttpGet]
    [Route("{idClient:int}")]
    public async Task<ActionResult<Response<ClientDto>>> GetById(int idClient)
    {
        var response = new Response<ClientDto>();
        
        if (!await _clientService.ClientExist(idClient))
        {
            response.Errors.Add("Client Not Found");
            return NotFound(response);
        }

        response.Data = await _clientService.GetByIdAsync(idClient);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ClientDto>>> Update([FromBody] ClientDto clientDto)
    {
        var response = new Response<ClientDto>();
        if (!await _clientService.ClientExist(clientDto.idClient))
        {
            response.Errors.Add("Client not found");
            return NotFound(response);
        }

        response.Data = await _clientService.UpdateAsync(clientDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{idClient:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idClient)
    {
        var response = new Response<bool>();

        if (!await _clientService.ClientExist(idClient))
        {
            response.Errors.Add("Client not found");
            return NotFound(response);
        }

        var isDeleted = await _clientService.DeleteAsync(idClient);

        if (isDeleted)
        {
            return Ok("Client Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete client");
            return BadRequest(response);
        }
    }
}