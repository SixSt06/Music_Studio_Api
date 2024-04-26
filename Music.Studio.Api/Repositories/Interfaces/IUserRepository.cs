using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IUserRepository
{
    //Método para guardar las categorías del producto
    Task<User> SaveAsync(User user);
    
    //Método para actualizar las categorías del producto
    Task<User> UpdateAsync(User user);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<User>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idUser);
    
    //Método para obtener una categoría por id
    Task<User> GetByIdAsync(int idUser);
}