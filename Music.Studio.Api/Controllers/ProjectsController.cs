using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Project>>>> GetAll()
    {
        var response = new Response<List<ProjectDto>>
        {
            Data = await _projectService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ProjectDto>>> Post([FromBody] ProjectDto projectDto)
    {
        var response = new Response<ProjectDto>
        {
            Data = await _projectService.SaveAsync(projectDto)
        };
        return Created($"/api/[controller]/{projectDto.idProject}", response);
    }
    
    [HttpGet]
    [Route("{idProject:int}")]
    public async Task<ActionResult<Response<ProjectDto>>> GetById(int idProject)
    {
        var response = new Response<ProjectDto>();
        
        if (!await _projectService.ProjectExist(idProject))
        {
            response.Errors.Add("Project Not Found");
            return NotFound(response);
        }

        response.Data = await _projectService.GetByIdAsync(idProject);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ProjectDto>>> Update([FromBody] ProjectDto projectDto)
    {
        var response = new Response<ProjectDto>();
        if (!await _projectService.ProjectExist(projectDto.idProject))
        {
            response.Errors.Add("Project not found");
            return NotFound(response);
        }

        response.Data = await _projectService.UpdateAsync(projectDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idProject:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idProject)
    {
        var response = new Response<bool>();

        if (!await _projectService.ProjectExist(idProject))
        {
            response.Errors.Add("Project not found");
            return NotFound(response);
        }

        var isDeleted = await _projectService.DeleteAsync(idProject);

        if (isDeleted)
        {
            return Ok("Project Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete Project");
            return BadRequest(response);
        }
    }
}