using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class ProjectRepository : IProjectRepositoy
{
    private readonly IDbContext _dbContext;

    public ProjectRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Project> SaveAsync(Project project)
    {
        project.idProject = await _dbContext.Connection.InsertAsync(project);
        return project;
    }

    public async Task<Project> UpdateAsync(Project project)
    {
        await _dbContext.Connection.UpdateAsync(project);
        return project;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Projects WHERE IsDeleted = 0";
        var projects = await _dbContext.Connection.QueryAsync<Project>(sql);

        return projects.ToList();
    }

    public async Task<bool> DeleteAsync(int idProject)
    {
        var project = await GetByIdAsync(idProject);
        if (project == null)
            return false;
        project.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(project);
    }

    public async Task<Project> GetByIdAsync(int idProject)
    {
        var project = await _dbContext.Connection.GetAsync<Project>(idProject);
        if (project == null)
            return null;
        return project.isDeleted == true ? null : project;
    }
}