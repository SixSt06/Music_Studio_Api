using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Equipment : EntityBase
{
    [ExplicitKey]
    public int idEquipment { get; set; }
    public string EquipmentName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}