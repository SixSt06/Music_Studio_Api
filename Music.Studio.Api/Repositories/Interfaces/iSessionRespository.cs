using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface iSessionRespository
{
    //Método para guardar las categorías del producto
    Task<Session> SaveAsync(Session session);
    
    //Método para actualizar las categorías del producto
    Task<Session> UpdateAsync(Session session);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Session>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idSession);
    
    //Método para obtener una categoría por id
    Task<Session> GetByIdAsync(int idSession);
}