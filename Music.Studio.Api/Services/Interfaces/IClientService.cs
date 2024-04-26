using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IClientService
{
    Task<bool> ClientExist(int idClient);
    //Método para guardar las categorías del producto
    Task<ClientDto> SaveAsync(ClientDto client);
    
    //Método para actualizar las categorías del producto
    Task<ClientDto> UpdateAsync(ClientDto client);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<ClientDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idClient);
    
    //Método para obtener una categoría por id
    Task<ClientDto> GetByIdAsync(int idClient);
}