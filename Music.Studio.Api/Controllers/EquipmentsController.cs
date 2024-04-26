using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EquipmentsController : ControllerBase
{
    private readonly IEquipmentService _equipmentService;

    public EquipmentsController(IEquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Equipment>>>> GetAll()
    {
        var response = new Response<List<EquipmentDto>>
        {
            Data = await _equipmentService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<EquipmentDto>>> Post([FromBody] EquipmentDto equipmentDto)
    {
        var response = new Response<EquipmentDto>
        {
            Data = await _equipmentService.SaveAsync(equipmentDto)
        };
        return Created($"/api/[controller]/{equipmentDto.idEquipment}", response);
    }
    
    [HttpGet]
    [Route("{idEquipment:int}")]
    public async Task<ActionResult<Response<EquipmentDto>>> GetById(int idEquipment)
    {
        var response = new Response<EquipmentDto>();
        
        if (!await _equipmentService.EquipmentExist(idEquipment))
        {
            response.Errors.Add("Equipment Not Found");
            return NotFound(response);
        }

        response.Data = await _equipmentService.GetByIdAsync(idEquipment);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<EquipmentDto>>> Update([FromBody] EquipmentDto equipmentDto)
    {
        var response = new Response<EquipmentDto>();
        if (!await _equipmentService.EquipmentExist(equipmentDto.idEquipment))
        {
            response.Errors.Add("Equipment not found");
            return NotFound(response);
        }

        response.Data = await _equipmentService.UpdateAsync(equipmentDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idEquipment:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idEquipment)
    {
        var response = new Response<bool>();

        if (!await _equipmentService.EquipmentExist(idEquipment))
        {
            response.Errors.Add("Equipment not found");
            return NotFound(response);
        }

        var isDeleted = await _equipmentService.DeleteAsync(idEquipment);

        if (isDeleted)
        {
            return Ok("Equipment Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete equipment");
            return BadRequest(response);
        }
    }
}