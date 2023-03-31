using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public class ServiceRepository : IServiceRepository
{
    private readonly ServiceDbContext context;
    private readonly ILogger<ServiceRepository> logger;
    
    public ServiceRepository(ServiceDbContext context, 
        ILogger<ServiceRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public IQueryable<Service> SelectServices()
    {
        return this.context.Services.AsQueryable();
    }

    public async ValueTask<Service> SelectServiceAsync(Guid id)
    {
        return await this.context.Services.FindAsync(id);
    }   

    public async ValueTask<Service> InsertServiceAsync(Service service)
    {
        service.Id = Guid.NewGuid();
        
        await this.context.Services.AddAsync(service);
        await this.context.SaveChangesAsync();
        
        this.logger.LogInformation("Service {ServiceId} created", service.Id);

        return service;
    }

    public async ValueTask<Service> UpdateServiceAsync(Service service)
    {
        this.context.Entry(service).State = EntityState.Modified;
        await this.context.SaveChangesAsync();
        
        this.logger.LogInformation("Service {ServiceId} updated", service.Id);

        return service;
    }

    public async ValueTask<Service> DeleteServiceAsync(Guid id)
    {
        var service = await this.context.Services.FindAsync(id);
        if (service == null)
        {
            return null;
        }
        this.context.Entry(service).State = EntityState.Deleted;
        await this.context.SaveChangesAsync();

        return service;
    }
}