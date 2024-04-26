using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IProjectRepositoy
{
    //Método para guardar las categorías del producto
    Task<Project> SaveAsync(Project project);
    
    //Método para actualizar las categorías del producto
    Task<Project> UpdateAsync(Project project);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Project>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idProject);
    
    //Método para obtener una categoría por id
    Task<Project> GetByIdAsync(int idProject);
}