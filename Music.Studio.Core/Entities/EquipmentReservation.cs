using System.Net.Mime;
using System.Security.AccessControl;
using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class EquipmentReservation : EntityBase
{
    [ExplicitKey]
    public int idReservation { get; set; }
    public int idEquipment_FK { get; set; }
    public int idSession_FK { get; set; }
    public DateTime ReservationDateTime { get; set; }
}