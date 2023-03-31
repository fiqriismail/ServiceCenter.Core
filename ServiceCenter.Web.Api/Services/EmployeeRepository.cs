using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ServiceDbContext context;


    public EmployeeRepository(ServiceDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Employee> SelectEmployees()
    {
        return this.context.Employees.AsQueryable();
    }

    public async ValueTask<Employee> SelectEmployeeAsync(Guid id)
    {
        return await this.context.Employees.FindAsync(id);
    }

    public async ValueTask<Employee> InsertEmployeeAsync(Employee employee)
    {
        employee.Id = Guid.NewGuid();

        await this.context.Employees.AddAsync(employee);
        await this.context.SaveChangesAsync();

        return employee;
    }

    public async ValueTask<Employee> UpdateEmployeeAsync(Employee employee)
    {
        this.context.Entry(employee).State = EntityState.Modified;
        await this.context.SaveChangesAsync();
        
        return employee;
    }

    public async ValueTask<Employee> DeleteEmployeeAsync(Employee employee)
    {
        this.context.Entry(employee).State = EntityState.Deleted;
        await this.context.SaveChangesAsync();
        
        return employee;
    }
}