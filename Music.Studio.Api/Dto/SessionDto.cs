using Music.Studio.Core;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class SessionDto
{
    public int idSession { get; set; }
    public DateTime DateTime  { get; set; }
    public string EstimatedDuration { get; set; }
    
    [NumericOnly(ErrorMessage = "Tipo de dato invalido.")]
    public int idProject_FK { get; set; }
    
    [NumericOnly(ErrorMessage = "Tipo de dato invalido.")]
    public int idEmployee_FK { get; set; }

    public SessionDto()
    {
        
    }

    public SessionDto(Session session)
    {
        idSession = session.idSession;
        DateTime = session.DateTime;
        EstimatedDuration = session.EstimatedDuration;
        idProject_FK = session.idProject_FK;
        idEmployee_FK = session.idEmployee_FK;
    }
}