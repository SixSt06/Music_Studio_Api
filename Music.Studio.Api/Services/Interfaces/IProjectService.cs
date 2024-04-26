using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IProjectService
{
    Task<bool> ProjectExist(int idProject);
    //Método para guardar las categorías del producto
    Task<ProjectDto> SaveAsync(ProjectDto project);
    
    //Método para actualizar las categorías del producto
    Task<ProjectDto> UpdateAsync(ProjectDto project);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<ProjectDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idProject);
    
    //Método para obtener una categoría por id
    Task<ProjectDto> GetByIdAsync(int idProject);
}