using Music.Studio.Core;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class EquipmentReservationDto
{
    public int idReservation { get; set; }
    public int idEquipment_FK { get; set; }
    public int idSession_FK { get; set; }
    public DateTime ReservationDateTime { get; set; }

    public EquipmentReservationDto()
    {
        
    }

    public EquipmentReservationDto(EquipmentReservation equipmentReservation)
    {
        idReservation = equipmentReservation.idReservation;
        idEquipment_FK = equipmentReservation.idEquipment_FK;
        idSession_FK = equipmentReservation.idSession_FK;
        ReservationDateTime = equipmentReservation.ReservationDateTime;
    }
}