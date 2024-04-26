using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Employee>>>> GetAll()
    {
        var response = new Response<List<EmployeeDto>>
        {
            Data = await _employeeService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<EmployeeDto>>> Post([FromBody] EmployeeDto employeeDto)
    {
        var response = new Response<EmployeeDto>
        {
            Data = await _employeeService.SaveAsync(employeeDto)
        };
        return Created($"/api/[controller]/{employeeDto.idEmployee}", response);
    }
    
    [HttpGet]
    [Route("{idEmployee:int}")]
    public async Task<ActionResult<Response<EmployeeDto>>> GetById(int idEmployee)
    {
        var response = new Response<EmployeeDto>();
        
        if (!await _employeeService.EmployeeExist(idEmployee))
        {
            response.Errors.Add("Employee Not Found");
            return NotFound(response);
        }

        response.Data = await _employeeService.GetByIdAsync(idEmployee);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<EmployeeDto>>> Update([FromBody] EmployeeDto employeeDto)
    {
        var response = new Response<EmployeeDto>();
        if (!await _employeeService.EmployeeExist(employeeDto.idEmployee))
        {
            response.Errors.Add("Employee not found");
            return NotFound(response);
        }

        response.Data = await _employeeService.UpdateAsync(employeeDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idEmployee:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idEmployee)
    {
        var response = new Response<bool>();

        if (!await _employeeService.EmployeeExist(idEmployee))
        {
            response.Errors.Add("Employee not found");
            return NotFound(response);
        }

        var isDeleted = await _employeeService.DeleteAsync(idEmployee);

        if (isDeleted)
        {
            return Ok("Employee Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete employee");
            return BadRequest(response);
        }
    }
}