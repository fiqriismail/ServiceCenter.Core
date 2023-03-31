using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public interface IEmployeeRepository
{
    IQueryable<Employee> SelectEmployees();
    ValueTask<Employee> SelectEmployeeAsync(Guid id);
    ValueTask<Employee> InsertEmployeeAsync(Employee employee);
    ValueTask<Employee> UpdateEmployeeAsync(Employee employee);
    ValueTask<Employee> DeleteEmployeeAsync(Employee employee);
    
}