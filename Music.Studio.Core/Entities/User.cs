using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class User : EntityBase
{
    [ExplicitKey]
    public int idUser { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int idEmployee_FK { get; set; }
}