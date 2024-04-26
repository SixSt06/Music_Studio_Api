using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _equipmentRepository;

    public EquipmentService(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }
    
    public async Task<bool> EquipmentExist(int idEquipment)
    {
        var equipment= await _equipmentRepository.GetByIdAsync(idEquipment);
        return (equipment != null);
    }

    public async Task<EquipmentDto> SaveAsync(EquipmentDto equipmentDto)
    {
        var equipment = new Equipment
        {
            EquipmentName = equipmentDto.EquipmentName,
            Description = equipmentDto.Description,
            Status = equipmentDto.Status,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        equipment = await _equipmentRepository.SaveAsync(equipment);
        equipmentDto.idEquipment = equipmentDto.idEquipment;
        return equipmentDto;
    }

    public async Task<EquipmentDto> UpdateAsync(EquipmentDto equipmentDto)
    {
        var equipment = await _equipmentRepository.GetByIdAsync(equipmentDto.idEquipment);

        if (equipment == null)
        {
            throw new Exception("Equipment not found");
        }

        equipment.EquipmentName = equipmentDto.EquipmentName;
        equipment.Description = equipmentDto.Description;
        equipment.Status = equipmentDto.Status;
        equipment.UpdatedBy = "";
        equipment.UpdatedDate = DateTime.Now;
        await _equipmentRepository.UpdateAsync(equipment);
        return equipmentDto;
    }

    public async Task<List<EquipmentDto>> GetAllAsync()
    {
        var equipments = await _equipmentRepository.GetAllAsync();
        var equipmentsDto = equipments.Select(c => new EquipmentDto(c)).ToList();
        return equipmentsDto;
    }

    public async Task<bool> DeleteAsync(int idEquipment)
    {
        return await _equipmentRepository.DeleteAsync(idEquipment);
    }

    public async Task<EquipmentDto> GetByIdAsync(int idEquipment)
    {
        var equipment = await _equipmentRepository.GetByIdAsync(idEquipment);
        if (equipment == null)
        {
            throw new Exception("Equipment not Found");
        }

        var equipmentDto = new EquipmentDto(equipment);
        return equipmentDto;
    }
}