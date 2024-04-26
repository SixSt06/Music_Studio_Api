using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Client : EntityBase
{
    [ExplicitKey]
    public int idClient { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
}