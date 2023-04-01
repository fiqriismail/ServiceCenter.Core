using Microsoft.AspNetCore.Cors;
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
    
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetService(Guid id)
    {
        var service = await this.serviceRepository.SelectServiceAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        
        return Ok(service);
    }

    [HttpPost]
    public async ValueTask<IActionResult> PostService([FromBody] Service service)
    {
        try
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
        catch (ArgumentNullException ex)
        {
            return this.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> PutService([FromBody] Service service)
    {
        if (service == null)
        {
            return this.BadRequest();
        }
        
        var updatedService = 
            await this.serviceRepository.UpdateServiceAsync(service);

        return Ok(updatedService);
    }
   
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteService(Guid id)
    {
        var deletedService = 
            await this.serviceRepository.DeleteServiceAsync(id);
        if (deletedService == null)
        {
            return NotFound();
        }
        
        return Ok(deletedService);
    }


}