using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IClientRepository
{
    //Método para guardar las categorías del producto
    Task<Client> SaveAsync(Client client);
    
    //Método para actualizar las categorías del producto
    Task<Client> UpdateAsync(Client client);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Client>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idClient);
    
    //Método para obtener una categoría por id
    Task<Client> GetByIdAsync(int idClient);
}