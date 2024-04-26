using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IEquipmentRepository
{
    //Método para guardar las categorías del producto
    Task<Equipment> SaveAsync(Equipment equipment);
    
    //Método para actualizar las categorías del producto
    Task<Equipment> UpdateAsync(Equipment equipment);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Equipment>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idEquipment);
    
    //Método para obtener una categoría por id
    Task<Equipment> GetByIdAsync(int idEquipment);
}