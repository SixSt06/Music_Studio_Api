using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class SessionRepository : iSessionRespository
{
    private readonly IDbContext _dbContext;

    public SessionRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Session> SaveAsync(Session session)
    {
        session.idSession = await _dbContext.Connection.InsertAsync(session);
        return session;
    }

    public async Task<Session> UpdateAsync(Session session)
    {
        await _dbContext.Connection.UpdateAsync(session);
        return session;
    }

    public async Task<List<Session>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Sessions WHERE IsDeleted = 0";
        var sessions = await _dbContext.Connection.QueryAsync<Session>(sql);

        return sessions.ToList();
    }

    public async Task<bool> DeleteAsync(int idSession)
    {
        var session = await GetByIdAsync(idSession);
        if (session == null)
            return false;
        session.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(session);
    }

    public async Task<Session> GetByIdAsync(int idSession)
    {
        var session = await _dbContext.Connection.GetAsync<Session>(idSession);
        if (session == null)
            return null;
        return session.isDeleted == true ? null : session;
    }
}