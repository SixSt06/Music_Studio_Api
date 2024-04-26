using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class EquipmentReservationService : IEquipmentReservationService
{
    
    private readonly IEquipmentReservationRepository _reservationRepository;

    public EquipmentReservationService(IEquipmentReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public async Task<bool> ReservationExist(int idReservation)
    {
        var reservation= await _reservationRepository.GetByIdAsync(idReservation);
        return (reservation != null);
    }

    public async Task<EquipmentReservationDto> SaveAsync(EquipmentReservationDto reservationDto)
    {
        var reservation = new EquipmentReservation
        {
            idEquipment_FK = reservationDto.idEquipment_FK,
            idSession_FK = reservationDto.idSession_FK,
            ReservationDateTime = reservationDto.ReservationDateTime,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        reservation = await _reservationRepository.SaveAsync(reservation);
        reservationDto.idReservation = reservationDto.idReservation;
        return reservationDto;
    }

    public async Task<EquipmentReservationDto> UpdateAsync(EquipmentReservationDto reservationDto)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationDto.idReservation);

        if (reservation == null)
        {
            throw new Exception("Reservation not found");
        }

        reservation.idEquipment_FK = reservationDto.idEquipment_FK;
        reservation.idSession_FK = reservationDto.idSession_FK;
        reservation.ReservationDateTime = reservationDto.ReservationDateTime;
        reservation.UpdatedBy = "";
        reservation.UpdatedDate = DateTime.Now;
        await _reservationRepository.UpdateAsync(reservation);
        return reservationDto;
    }

    public async Task<List<EquipmentReservationDto>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        var reservationsDto = reservations.Select(c => new EquipmentReservationDto(c)).ToList();
        return reservationsDto;
    }

    public async Task<bool> DeleteAsync(int idReservation)
    {
        return await _reservationRepository.DeleteAsync(idReservation);
    }

    public async Task<EquipmentReservationDto> GetByIdAsync(int idReservation)
    {
        var reservation = await _reservationRepository.GetByIdAsync(idReservation);
        if (reservation == null)
        {
            throw new Exception("Reservation not Found");
        }

        var reservationDto = new EquipmentReservationDto(reservation);
        return reservationDto;
    }
}