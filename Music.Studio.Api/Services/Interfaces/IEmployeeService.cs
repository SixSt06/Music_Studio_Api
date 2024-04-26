using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IEmployeeService
{
    Task<bool> EmployeeExist(int idEmployee);
    //Método para guardar las categorías del producto
    Task<EmployeeDto> SaveAsync(EmployeeDto employee);
    
    //Método para actualizar las categorías del producto
    Task<EmployeeDto> UpdateAsync(EmployeeDto employee);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<EmployeeDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idEmployee);
    
    //Método para obtener una categoría por id
    Task<EmployeeDto> GetByIdAsync(int idEmployee);
}