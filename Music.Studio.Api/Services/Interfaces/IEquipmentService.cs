using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IEquipmentService
{
    Task<bool> EquipmentExist(int idEquipment);
    //Método para guardar las categorías del producto
    Task<EquipmentDto> SaveAsync(EquipmentDto equipment);
    
    //Método para actualizar las categorías del producto
    Task<EquipmentDto> UpdateAsync(EquipmentDto equipment);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<EquipmentDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idEquipment);
    
    //Método para obtener una categoría por id
    Task<EquipmentDto> GetByIdAsync(int idEquipment);
}