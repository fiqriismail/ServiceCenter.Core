namespace ServiceCenter.Web.Api.Models;

public class Job
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    
    public Guid VehicleId { get; set; }
    public Guid ServiceId { get; set; }
    public Guid EmployeeId { get; set; }
}