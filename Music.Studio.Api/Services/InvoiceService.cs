using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoicesRepository _invoicesRepository;

    public InvoiceService(IInvoicesRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }
    
    public async Task<bool> InvoicetExist(int idInvoice)
    {
        var invoice= await _invoicesRepository.GetByIdAsync(idInvoice);
        return (invoice != null);
    }

    public async Task<InvoiceDto> SaveAsync(InvoiceDto invoiceDto)
    {
        var invoice = new Invoice
        {
            idProject_FK = invoiceDto.idProject_FK,
            IssuanceDate = invoiceDto.IssuanceDate,
            TotalAmount = invoiceDto.TotalAmount,
            PaymentStatus = invoiceDto.PaymentStatus,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        invoice = await _invoicesRepository.SaveAsync(invoice);
        invoiceDto.idInvoice = invoiceDto.idInvoice;
        return invoiceDto;
    }

    public async Task<InvoiceDto> UpdateAsync(InvoiceDto invoiceDto)
    {
        var invoice = await _invoicesRepository.GetByIdAsync(invoiceDto.idInvoice);

        if (invoice == null)
        {
            throw new Exception("Invoice not found");
        }

        invoice.idProject_FK = invoiceDto.idProject_FK;
        invoice.IssuanceDate = invoiceDto.IssuanceDate;
        invoice.TotalAmount = invoiceDto.TotalAmount;
        invoice.PaymentStatus = invoiceDto.PaymentStatus;
        invoice.UpdatedBy = "";
        invoice.UpdatedDate = DateTime.Now;
        await _invoicesRepository.UpdateAsync(invoice);
        return invoiceDto;
    }

    public async Task<List<InvoiceDto>> GetAllAsync()
    {
        var invoice = await _invoicesRepository.GetAllAsync();
        var invoicesDto = invoice.Select(c => new InvoiceDto(c)).ToList();
        return invoicesDto;
    }

    public async Task<bool> DeleteAsync(int idInvoice)
    {
        return await _invoicesRepository.DeleteAsync(idInvoice);
    }

    public async Task<InvoiceDto> GetByIdAsync(int idInvoice)
    {
        var invoice = await _invoicesRepository.GetByIdAsync(idInvoice);
        if (invoice == null)
        {
            throw new Exception("Invoice not Found");
        }

        var invoiceDto = new InvoiceDto(invoice);
        return invoiceDto;
    }
}