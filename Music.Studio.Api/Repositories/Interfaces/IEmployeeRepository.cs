using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IEmployeeRepository
{
    //Método para guardar las categorías del producto
    Task<Employee> SaveAsync(Employee employee);
    
    //Método para actualizar las categorías del producto
    Task<Employee> UpdateAsync(Employee employee);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Employee>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idEmployee);
    
    //Método para obtener una categoría por id
    Task<Employee> GetByIdAsync(int idEmployee);
}