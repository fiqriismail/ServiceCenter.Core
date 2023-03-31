using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public interface IVehicleRepository
{
    IQueryable<Vehicle> SelectVehicles();
    ValueTask<Vehicle> SelectVehicleAsync(Guid id);
    ValueTask<Vehicle> InsertVehicleAsync(Vehicle vehicle);
    ValueTask<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    ValueTask<Vehicle> DeleteVehicleAsync(Vehicle vehicle);
}