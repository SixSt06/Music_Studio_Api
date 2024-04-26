using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<User>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>
        {
            Data = await _userService.SaveAsync(userDto)
        };
        return Created($"/api/[controller]/{userDto.idUser}", response);
    }
    
    [HttpGet]
    [Route("{idUser:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int idUser)
    {
        var response = new Response<UserDto>();
        
        if (!await _userService.UserExist(idUser))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }

        response.Data = await _userService.GetByIdAsync(idUser);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<UserDto>>> Update([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>();
        if (!await _userService.UserExist(userDto.idUser))
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        response.Data = await _userService.UpdateAsync(userDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idUser:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idUser)
    {
        var response = new Response<bool>();

        if (!await _userService.UserExist(idUser))
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        var isDeleted = await _userService.DeleteAsync(idUser);

        if (isDeleted)
        {
            return Ok("User Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete user");
            return BadRequest(response);
        }
    }
}