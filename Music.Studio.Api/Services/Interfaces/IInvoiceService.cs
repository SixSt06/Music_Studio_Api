using Music.Studio.Api.Dto;

namespace Music.Studio.Api.Services.Interfaces;

public interface IInvoiceService
{
    Task<bool> InvoicetExist(int idInvoice);
    //Método para guardar las categorías del producto
    Task<InvoiceDto> SaveAsync(InvoiceDto invoice);
    
    //Método para actualizar las categorías del producto
    Task<InvoiceDto> UpdateAsync(InvoiceDto invoice);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<InvoiceDto>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idInvoice);
    
    //Método para obtener una categoría por id
    Task<InvoiceDto> GetByIdAsync(int idInvoice);
}