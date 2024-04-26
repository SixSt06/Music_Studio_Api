using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<bool> EmployeeExist(int idEmployee)
    {
        var employee = await _employeeRepository.GetByIdAsync(idEmployee);
        return (employee != null);
    }

    public async Task<EmployeeDto> SaveAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            Position = employeeDto.Position,
            Phone = employeeDto.Phone,
            Email = employeeDto.Email,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        employee = await _employeeRepository.SaveAsync(employee);
        employeeDto.idEmployee = employeeDto.idEmployee;
        return employeeDto;
    }

    public async Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.GetByIdAsync(employeeDto.idEmployee);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        employee.Name = employeeDto.Name;
        employee.Position = employeeDto.Position;
        employee.Phone = employeeDto.Phone;
        employee.Email = employeeDto.Email;
        employee.UpdatedBy = "";
        employee.UpdatedDate = DateTime.Now;
        await _employeeRepository.UpdateAsync(employee);
        return employeeDto;
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var employee = await _employeeRepository.GetAllAsync();
        var employeesDto = employee.Select(c => new EmployeeDto(c)).ToList();
        return employeesDto;
    }

    public async Task<bool> DeleteAsync(int idEmployee)
    {
        return await _employeeRepository.DeleteAsync(idEmployee);
    }

    public async Task<EmployeeDto> GetByIdAsync(int idEmployee)
    {
        var employee = await _employeeRepository.GetByIdAsync(idEmployee);
        if (employee == null)
        {
            throw new Exception("Employee not Found");
        }

        var employeeDto = new EmployeeDto(employee);
        return employeeDto;
    }
}