using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Project : EntityBase
{
    [ExplicitKey]
    public int idProject { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string ExpectedEndDate { get; set; }

    public int idClient_FK { get; set; }
        
}