using Music.Studio.Core;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class InvoiceDto
{
    public int idInvoice { get; set; }
    
    [NumericOnly(ErrorMessage = "Tipo de dato invalido.")]
    public int idProject_FK { get; set; }
    public DateTime IssuanceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; }

    public InvoiceDto()
    {
        
    }
    
    public InvoiceDto(Invoice invoice)
    {
        idInvoice = invoice.idInvoice;
        idProject_FK = invoice.idProject_FK;
        IssuanceDate = invoice.IssuanceDate;
        TotalAmount = invoice.TotalAmount;
        PaymentStatus = invoice.PaymentStatus;
    }
}