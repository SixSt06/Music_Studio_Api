using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDbContext _dbContext;

    public ClientRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Client> SaveAsync(Client client)
    {
        client.idClient = await _dbContext.Connection.InsertAsync(client);
        return client;
    }

    public async Task<Client> UpdateAsync(Client client)
    {
        await _dbContext.Connection.UpdateAsync(client);
        return client;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Clients WHERE IsDeleted = 0";
        var clients = await _dbContext.Connection.QueryAsync<Client>(sql);

        return clients.ToList();
    }

    public async Task<bool> DeleteAsync(int idClient)
    {
        var client = await GetByIdAsync(idClient);
        if (client == null)
            return false;
        client.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(client);
    }

    public async Task<Client> GetByIdAsync(int idClient)
    {
        var client = await _dbContext.Connection.GetAsync<Client>(idClient);
        if (client == null)
            return null;
        return client.isDeleted == true ? null : client;
    }
}