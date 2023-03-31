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

    public ValueTask<Service> SelectServiceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Service> InsertServiceAsync(Service service)
    {
        service.Id = Guid.NewGuid();
        
        await this.context.Services.AddAsync(service);
        await this.context.SaveChangesAsync();
        
        this.logger.LogInformation("Service {ServiceId} created", service.Id);

        return service;
    }

    public ValueTask<Service> UpdateServiceAsync(Service service)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Service> DeleteServiceAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}