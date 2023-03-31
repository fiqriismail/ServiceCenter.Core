using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;
using ServiceCenter.Web.Api.Services;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceRepository serviceRepository;
    
    public ServicesController(IServiceRepository serviceRepository)
    {
        this.serviceRepository = serviceRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllServices()
    {
        var servicesQuery = this.serviceRepository.SelectServices();
        var services = servicesQuery.ToList();
        return this.Ok(services);
    }

    [HttpPost]
    public async ValueTask<IActionResult> PostService([FromBody] Service service)
    {
        if (service == null)
        {
            return this.BadRequest();
        }
        
        var createdService = 
            await this.serviceRepository.InsertServiceAsync(service);

        return Created($"/api/services/{createdService.Id}", 
            createdService);
    }


}