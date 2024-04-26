using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories.Interfaces;

public interface IInvoicesRepository
{
    //Método para guardar las categorías del producto
    Task<Invoice> SaveAsync(Invoice invoice);
    
    //Método para actualizar las categorías del producto
    Task<Invoice> UpdateAsync(Invoice invoice);
    
    //Método para retornar una lista de las categorías del producto
    Task<List<Invoice>> GetAllAsync();
    
    //Método para retornar el id de las categorías del producto que se borró
    Task<bool> DeleteAsync(int idInvoice);
    
    //Método para obtener una categoría por id
    Task<Invoice> GetByIdAsync(int idInvoice);
}