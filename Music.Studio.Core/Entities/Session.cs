using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Session : EntityBase
{
    [ExplicitKey]
    public int idSession { get; set; }
    public DateTime DateTime  { get; set; }
    public string EstimatedDuration { get; set; }
    public int idProject_FK { get; set; }
    public int idEmployee_FK { get; set; }
    
}