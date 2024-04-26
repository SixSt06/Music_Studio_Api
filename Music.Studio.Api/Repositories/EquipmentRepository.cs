using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly IDbContext _dbContext;

    public EquipmentRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Equipment> SaveAsync(Equipment equipment)
    {
        equipment.idEquipment = await _dbContext.Connection.InsertAsync(equipment);
        return equipment;
    }

    public async Task<Equipment> UpdateAsync(Equipment equipment)
    {
        await _dbContext.Connection.UpdateAsync(equipment);
        return equipment;
    }

    public async Task<List<Equipment>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Equipments WHERE IsDeleted = 0";
        var equipments = await _dbContext.Connection.QueryAsync<Equipment>(sql);

        return equipments.ToList();
    }

    public async Task<bool> DeleteAsync(int idEquipment)
    {
        var equipment = await GetByIdAsync(idEquipment);
        if (equipment == null)
            return false;
        equipment.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(equipment);
    }

    public async Task<Equipment> GetByIdAsync(int idEquipment)
    {
        var equipment = await _dbContext.Connection.GetAsync<Equipment>(idEquipment);
        if (equipment == null)
            return null;
        return equipment.isDeleted == true ? null : equipment;
    }
}