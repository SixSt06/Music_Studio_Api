using Music.Studio.Core;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class ProjectDto
{
    public int idProject { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string ExpectedEndDate { get; set; }
    
    [NumericOnly(ErrorMessage = "Tipo de dato invalido.")]
    public int idClient_FK { get; set; }

    public ProjectDto()
    {
        
    }
    
    public ProjectDto(Project project)
    {
        idProject = project.idProject;
        Name = project.Name;
        Description = project.Description;
        StartDate = project.StartDate;
        ExpectedEndDate = project.ExpectedEndDate;
        idClient_FK = project.idClient_FK;
    }
}