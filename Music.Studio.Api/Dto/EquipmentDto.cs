using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class EquipmentDto
{
    public int idEquipment { get; set; }
    public string EquipmentName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    public EquipmentDto()
    {
        
    }

    public EquipmentDto(Equipment equipment)
    {
        idEquipment = equipment.idEquipment;
        EquipmentName = equipment.EquipmentName;
        Description = equipment.Description;
        Status = equipment.Status;
    }
}