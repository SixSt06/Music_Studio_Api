using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IUserService
{
    Task<bool> UserExist(int idUser);
    //Método para guardar las categorías del producto
    Task<UserDto> SaveAsync(UserDto user);
    
    //Método para actualizar las categorías del producto
    Task<UserDto> UpdateAsync(UserDto user);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<UserDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idUser);
    
    //Método para obtener una categoría por id
    Task<UserDto> GetByIdAsync(int idUser);
}