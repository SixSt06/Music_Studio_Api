using Dapper;
using Dapper.Contrib.Extensions;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbContext _dbContext;

    public EmployeeRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Employee> SaveAsync(Employee employee)
    {
        employee.idEmployee = await _dbContext.Connection.InsertAsync(employee);
        return employee;
        
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        await _dbContext.Connection.UpdateAsync(employee);
        return employee;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Employees WHERE IsDeleted = 0";
        var employees = await _dbContext.Connection.QueryAsync<Employee>(sql);

        return employees.ToList();
    }

    public async Task<bool> DeleteAsync(int idEmployee)
    {
        var employee = await GetByIdAsync(idEmployee);
        if (employee == null)
            return false;
        employee.isDeleted = true;

        return await _dbContext.Connection.UpdateAsync(employee);
    }

    public async Task<Employee> GetByIdAsync(int idEmployee)
    {
        var employee = await _dbContext.Connection.GetAsync<Employee>(idEmployee);
        if (employee == null)
            return null;
        return employee.isDeleted == true ? null : employee;
    }
}