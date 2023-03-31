using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public interface IServiceRepository
{
    IQueryable<Service> SelectServices();
    ValueTask<Service> SelectServiceAsync(Guid id);
    ValueTask<Service> InsertServiceAsync(Service service);
    ValueTask<Service> UpdateServiceAsync(Service service);
    ValueTask<Service> DeleteServiceAsync(Guid id);
}