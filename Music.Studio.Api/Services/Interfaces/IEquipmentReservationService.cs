using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IEquipmentReservationService
{
    Task<bool> ReservationExist(int idReservation);
    //Método para guardar las categorías del producto
    Task<EquipmentReservationDto> SaveAsync(EquipmentReservationDto reservation);
    
    //Método para actualizar las categorías del producto
    Task<EquipmentReservationDto> UpdateAsync(EquipmentReservationDto reservation);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<EquipmentReservationDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idReservation);
    
    //Método para obtener una categoría por id
    Task<EquipmentReservationDto> GetByIdAsync(int idReservation);
}