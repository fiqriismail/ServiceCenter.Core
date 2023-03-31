using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public partial class ServiceRepository : IServiceRepository
{
    private void ValidateOnInsert(Service service)
    {
        if (service.Title == null)
        {
            throw new ArgumentNullException(nameof(service.Title));
        }
    }
}