using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class EquipmentReservationRepository : IEquipmentReservationRepository
{
    
    private readonly IDbContext _dbContext;

    public EquipmentReservationRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<EquipmentReservation> SaveAsync(EquipmentReservation equipmentReservation)
    {
        equipmentReservation.idReservation = await _dbContext.Connection.InsertAsync(equipmentReservation);
        return equipmentReservation;
    }

    public async Task<EquipmentReservation> UpdateAsync(EquipmentReservation equipmentReservation)
    {
        await _dbContext.Connection.UpdateAsync(equipmentReservation);
        return equipmentReservation;
    }

    public async Task<List<EquipmentReservation>> GetAllAsync()
    {
        const string sql = "SELECT * FROM EquipmentReservations WHERE IsDeleted = 0";
        var reservations = await _dbContext.Connection.QueryAsync<EquipmentReservation>(sql);

        return reservations.ToList();
    }

    public async Task<bool> DeleteAsync(int idReservation)
    {
        var reservation = await GetByIdAsync(idReservation);
        if (reservation == null)
            return false;
        reservation.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(reservation);
    }

    public async Task<EquipmentReservation> GetByIdAsync(int idReservation)
    {
        var reservation = await _dbContext.Connection.GetAsync<EquipmentReservation>(idReservation);
        if (reservation == null)
            return null;
        return reservation.isDeleted == true ? null : reservation;
    }
}