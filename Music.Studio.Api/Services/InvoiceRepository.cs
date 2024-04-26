using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class InvoiceRepository : IInvoicesRepository
{
    private readonly IDbContext _dbContext;

    public InvoiceRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Invoice> SaveAsync(Invoice invoice)
    {
        invoice.idInvoice = await _dbContext.Connection.InsertAsync(invoice);
        return invoice;
    }

    public async Task<Invoice> UpdateAsync(Invoice invoice)
    {
        await _dbContext.Connection.UpdateAsync(invoice);
        return invoice;
    }

    public async Task<List<Invoice>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Invoices WHERE IsDeleted = 0";
        var invoices = await _dbContext.Connection.QueryAsync<Invoice>(sql);

        return invoices.ToList();
    }

    public async  Task<bool> DeleteAsync(int idInvoice)
    {
        var invoice = await GetByIdAsync(idInvoice);
        if (invoice == null)
            return false;
        invoice.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(invoice);
    }

    public async Task<Invoice> GetByIdAsync(int idInvoice)
    {
        var invoice = await _dbContext.Connection.GetAsync<Invoice>(idInvoice);
        if (invoice == null)
            return null;
        return invoice.isDeleted == true ? null : invoice;
    }
}