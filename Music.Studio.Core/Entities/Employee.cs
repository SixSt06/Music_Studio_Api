using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Employee : EntityBase
{
    [ExplicitKey]
    public int idEmployee { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}