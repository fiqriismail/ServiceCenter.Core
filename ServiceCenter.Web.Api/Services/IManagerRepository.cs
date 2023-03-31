using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public interface IManagerRepository
{
    IQueryable<Manager> SelectManagers();
    ValueTask<Manager> SelectManagerAsync(Guid id);
    ValueTask<Manager> InsertManagerAsync(Manager manager);
    ValueTask<Manager> UpdateManagerAsync(Manager manager);
    ValueTask<Manager> DeleteManagerAsync(Manager manager);
    
}