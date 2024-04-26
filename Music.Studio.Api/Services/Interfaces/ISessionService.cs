using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services;

public interface ISessionService
{
    Task<bool> SessionExist(int idSession);
    //Método para guardar las categorías del producto
    Task<SessionDto> SaveAsync(SessionDto session);
    
    //Método para actualizar las categorías del producto
    Task<SessionDto> UpdateAsync(SessionDto session);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<SessionDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idSession);
    
    //Método para obtener una categoría por id
    Task<SessionDto> GetByIdAsync(int idSession);
}