using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Services;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Session>>>> GetAll()
    {
        var response = new Response<List<SessionDto>>
        {
            Data = await _sessionService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<SessionDto>>> Post([FromBody] SessionDto sessionDto)
    {
        var response = new Response<SessionDto>
        {
            Data = await _sessionService.SaveAsync(sessionDto)
        };
        return Created($"/api/[controller]/{sessionDto.idSession}", response);
    }
    
    [HttpGet]
    [Route("{idSession:int}")]
    public async Task<ActionResult<Response<SessionDto>>> GetById(int idSession)
    {
        var response = new Response<SessionDto>();
        
        if (!await _sessionService.SessionExist(idSession))
        {
            response.Errors.Add("Session Not Found");
            return NotFound(response);
        }

        response.Data = await _sessionService.GetByIdAsync(idSession);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<SessionDto>>> Update([FromBody] SessionDto sessionDto)
    {
        var response = new Response<SessionDto>();
        if (!await _sessionService.SessionExist(sessionDto.idSession))
        {
            response.Errors.Add("Session not found");
            return NotFound(response);
        }

        response.Data = await _sessionService.UpdateAsync(sessionDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idSession:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idSession)
    {
        var response = new Response<bool>();

        if (!await _sessionService.SessionExist(idSession))
        {
            response.Errors.Add("Session not found");
            return NotFound(response);
        }

        var isDeleted = await _sessionService.DeleteAsync(idSession);

        if (isDeleted)
        {
            return Ok("Session Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete session");
            return BadRequest(response);
        }
    }
}