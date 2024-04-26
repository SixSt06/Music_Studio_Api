using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class ProjectService : IProjectService
{
    
    private readonly IProjectRepositoy _projectRepositoy;

    public ProjectService(IProjectRepositoy projectRepositoy)
    {
        _projectRepositoy = projectRepositoy;
    }
    
    public async Task<bool> ProjectExist(int idProject)
    {
        var project= await _projectRepositoy.GetByIdAsync(idProject);
        return (project != null);
    }

    public async Task<ProjectDto> SaveAsync(ProjectDto projectDto)
    {
        var project = new Project
        {
            Name = projectDto.Name,
            Description = projectDto.Description,
            StartDate = projectDto.StartDate,
            ExpectedEndDate = projectDto.ExpectedEndDate,
            idClient_FK = projectDto.idClient_FK,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        project = await _projectRepositoy.SaveAsync(project);
        projectDto.idProject = projectDto.idProject;
        return projectDto;
    }

    public async Task<ProjectDto> UpdateAsync(ProjectDto projectDto)
    {
        var project = await _projectRepositoy.GetByIdAsync(projectDto.idProject);

        if (project == null)
        {
            throw new Exception("Project not found");
        }

        project.Name = projectDto.Name;
        project.Description = projectDto.Description;
        project.StartDate = projectDto.StartDate;
        project.ExpectedEndDate = projectDto.ExpectedEndDate;
        project.idClient_FK = projectDto.idClient_FK;
        project.UpdatedBy = "";
        project.UpdatedDate = DateTime.Now;
        await _projectRepositoy.UpdateAsync(project);
        return projectDto;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var project = await _projectRepositoy.GetAllAsync();
        var projectsDto = project.Select(c => new ProjectDto(c)).ToList();
        return projectsDto;
    }

    public async Task<bool> DeleteAsync(int idProject)
    {
        return await _projectRepositoy.DeleteAsync(idProject);
    }

    public async Task<ProjectDto> GetByIdAsync(int idProject)
    {
        var project = await _projectRepositoy.GetByIdAsync(idProject);
        if (project == null)
        {
            throw new Exception("Project not Found");
        }

        var projectDto = new ProjectDto(project);
        return projectDto;
    }
}