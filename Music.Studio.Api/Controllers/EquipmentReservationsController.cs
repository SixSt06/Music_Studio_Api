using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EquipmentReservationsController : ControllerBase
{
    private readonly IEquipmentReservationService _equipmentReservationService;

    public EquipmentReservationsController(IEquipmentReservationService equipmentReservationService)
    {
        _equipmentReservationService = equipmentReservationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<EquipmentReservation>>>> GetAll()
    {
        var response = new Response<List<EquipmentReservationDto>>
        {
            Data = await _equipmentReservationService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<EquipmentReservationDto>>> Post([FromBody] EquipmentReservationDto reservationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = new Response<EquipmentReservationDto>
        {
            Data = await _equipmentReservationService.SaveAsync(reservationDto)
        };
        return Created($"/api/[controller]/{reservationDto.idReservation}", response);
    }
    
    [HttpGet]
    [Route("{idReservation:int}")]
    public async Task<ActionResult<Response<EquipmentReservationDto>>> GetById(int idReservation)
    {
        var response = new Response<EquipmentReservationDto>();
        
        if (!await _equipmentReservationService.ReservationExist(idReservation))
        {
            response.Errors.Add("Reservation Not Found");
            return NotFound(response);
        }

        response.Data = await _equipmentReservationService.GetByIdAsync(idReservation);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<EquipmentReservationDto>>> Update([FromBody] EquipmentReservationDto reservationDto)
    {
        var response = new Response<EquipmentReservationDto>();
        if (!await _equipmentReservationService.ReservationExist(reservationDto.idReservation))
        {
            response.Errors.Add("Reservation not found");
            return NotFound(response);
        }

        response.Data = await _equipmentReservationService.UpdateAsync(reservationDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idReservation:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idReservation)
    {
        var response = new Response<bool>();

        if (!await _equipmentReservationService.ReservationExist(idReservation))
        {
            response.Errors.Add("Reservation not found");
            return NotFound(response);
        }

        var isDeleted = await _equipmentReservationService.DeleteAsync(idReservation);

        if (isDeleted)
        {
            return Ok("Reservation Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete reservation");
            return BadRequest(response);
        }
    }
}

