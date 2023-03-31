using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public class ManagerRepository : IManagerRepository
{
    private readonly ServiceDbContext context;
    
    public ManagerRepository(ServiceDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<Manager> SelectManagers()
    {
        return this.context.Managers.AsQueryable();
    }

    public async ValueTask<Manager> SelectManagerAsync(Guid id)
    {
        return await this.context.Managers.FindAsync(id);
    }

    public async ValueTask<Manager> InsertManagerAsync(Manager manager)
    {
        manager.Id = Guid.NewGuid();
        
        await this.context.Managers.AddAsync(manager);
        await this.context.SaveChangesAsync();
        
        return manager;
    }

    public async ValueTask<Manager> UpdateManagerAsync(Manager manager)
    {
        this.context.Entry(manager).State = EntityState.Modified;
        await this.context.SaveChangesAsync();
        
        return manager;
    }

    public async ValueTask<Manager> DeleteManagerAsync(Manager manager)
    {
        this.context.Entry(manager).State = EntityState.Deleted;
        await this.context.SaveChangesAsync();
        
        return manager;
    }
}