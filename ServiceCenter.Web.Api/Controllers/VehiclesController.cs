using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;
using ServiceCenter.Web.Api.Services;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleRepository vehicleRepository;
    
    public VehiclesController(IVehicleRepository vehicleRepository)
    {
        this.vehicleRepository = vehicleRepository;
    }
    
    [HttpGet]
    public IActionResult GetVehicles()
    {
        var vehicleQuery = this.vehicleRepository.SelectVehicles();
        var vehicles = vehicleQuery.ToList();
        
        return Ok(vehicles);
    }
    
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetVehicle(Guid id)
    {
        var vehicle = await this.vehicleRepository.SelectVehicleAsync(id);
        
        if (vehicle is null)
        {
            return NotFound();
        }
        
        return Ok(vehicle);
    }
    
    [HttpPost]
    public async ValueTask<IActionResult> PostVehicle([FromBody] Vehicle vehicle)
    {
        if (vehicle is null)
        {
            return BadRequest();
        }
        
        var newVehicle = await this.vehicleRepository.InsertVehicleAsync(vehicle);
        
        return CreatedAtAction(nameof(GetVehicles), 
            new { id = newVehicle.Id }, newVehicle);
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> PutVehicle([FromBody] Vehicle vehicle)
    {
        var existingVehicle = await this.vehicleRepository.SelectVehicleAsync(vehicle.Id);
        
        if (existingVehicle is null)
        {
            return NotFound();
        }
        
        var updatedVehicle = await this.vehicleRepository.UpdateVehicleAsync(vehicle);
        
        return Ok(updatedVehicle);
    }
    
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteVehicle(Guid id)
    {
        var existingVehicle = await this.vehicleRepository.SelectVehicleAsync(id);
        
        if (existingVehicle is null)
        {
            return NotFound();
        }
        
        var deletedVehicle = await this.vehicleRepository.DeleteVehicleAsync(existingVehicle);
        
        return Ok(deletedVehicle);
    }
}