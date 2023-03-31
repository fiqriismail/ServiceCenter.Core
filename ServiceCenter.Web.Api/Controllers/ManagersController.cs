using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;
using ServiceCenter.Web.Api.Services;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManagersController : ControllerBase
{
    private readonly IManagerRepository managerRepository;
    
    public ManagersController(IManagerRepository managerRepository)
    {
        this.managerRepository = managerRepository;
    }   
    
    [HttpGet]
    public IActionResult GetManagers()
    {
        var managerQuery = this.managerRepository.SelectManagers();
        var managers = managerQuery.ToList();
        
        return Ok(managers);
    }
    
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetManager(Guid id)
    {
        var manager = await this.managerRepository.SelectManagerAsync(id);
        
        if (manager is null)
        {
            return NotFound();
        }
        
        return Ok(manager);
    }
    
    [HttpPost]
    public async ValueTask<IActionResult> PostManager([FromBody] Manager manager)
    {
        if (manager is null)
        {
            return BadRequest();
        }
        
        var newManager = await this.managerRepository.InsertManagerAsync(manager);
        
        return CreatedAtAction(nameof(GetManagers), 
            new { id = newManager.Id }, newManager);
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> PutManager([FromBody] Manager manager)
    {
        var existingManager = await this.managerRepository.SelectManagerAsync(manager.Id);
        
        if (existingManager is null)
        {
            return NotFound();
        }
        
        var updatedManager = await this.managerRepository.UpdateManagerAsync(manager);
        
        return Ok(updatedManager);
    }
    
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteManager(Guid id)
    {
        var existingManager = await this.managerRepository.SelectManagerAsync(id);
        
        if (existingManager is null)
        {
            return NotFound();
        }
        
        var deletedManager = await this.managerRepository.DeleteManagerAsync(existingManager);
        
        return Ok(deletedManager);
    }
}