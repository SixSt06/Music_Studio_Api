using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IEquipmentReservationRepository
{
    //Método para guardar las categorías del producto
    Task<EquipmentReservation> SaveAsync(EquipmentReservation equipmentReservation);
    
    //Método para actualizar las categorías del producto
    Task<EquipmentReservation> UpdateAsync(EquipmentReservation equipmentReservation);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<EquipmentReservation>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idReservation);
    
    //Método para obtener una categoría por id
    Task<EquipmentReservation> GetByIdAsync(int idReservation);
}