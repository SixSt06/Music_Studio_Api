using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class EmployeeDto
{
    public int idEmployee { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public EmployeeDto()
    {
        
    }

    public EmployeeDto(Employee employee)
    {
        idEmployee = employee.idEmployee;
        Name = employee.Name;
        Position = employee.Position;
        Phone = employee.Phone;
        Email = employee.Email;
    }
}