namespace ServiceCenter.Web.Api.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public string Owner { get; set; }
}