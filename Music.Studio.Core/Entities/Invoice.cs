using Dapper.Contrib.Extensions;

namespace Music.Studio.Core.Entities;

public class Invoice : EntityBase
{
    [ExplicitKey]
    public int idInvoice { get; set; }
    public int idProject_FK { get; set; }
    public DateTime IssuanceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; }
}