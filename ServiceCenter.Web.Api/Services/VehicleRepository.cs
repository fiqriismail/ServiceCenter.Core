using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public class VehicleRepository : IVehicleRepository
{
    private readonly ServiceDbContext context;
    
    public VehicleRepository(ServiceDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<Vehicle> SelectVehicles()
    {
        return this.context.Vehicles.AsQueryable();
    }

    public async ValueTask<Vehicle> SelectVehicleAsync(Guid id)
    {
        return await this.context.Vehicles.FindAsync(id);
    }

    public async ValueTask<Vehicle> InsertVehicleAsync(Vehicle vehicle)
    {
        vehicle.Id = Guid.NewGuid();
        
        await this.context.Vehicles.AddAsync(vehicle);
        await this.context.SaveChangesAsync();
        
        return vehicle;
    }

    public async ValueTask<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
    {
        this.context.Entry(vehicle).State = EntityState.Modified;
        await this.context.SaveChangesAsync();
        
        return vehicle;
    }

    public async ValueTask<Vehicle> DeleteVehicleAsync(Vehicle vehicle)
    {
        this.context.Entry(vehicle).State = EntityState.Deleted;
        await this.context.SaveChangesAsync();
        
        return vehicle;
    }
}
