using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<User> SaveAsync(User user)
    {
        user.idUser = await _dbContext.Connection.InsertAsync(user);
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _dbContext.Connection.UpdateAsync(user);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Users WHERE IsDeleted = 0";
        var users = await _dbContext.Connection.QueryAsync<User>(sql);

        return users.ToList();
    }

    public async Task<bool> DeleteAsync(int idUser)
    {
        var user = await GetByIdAsync(idUser);
        if (user == null)
            return false;
        user.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(user);
    }

    public async Task<User> GetByIdAsync(int idUser)
    {
        var user = await _dbContext.Connection.GetAsync<User>(idUser);
        if (user == null)
            return null;
        return user.isDeleted == true ? null : user;
    }
}