using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Database;

public class ServiceDbContext : DbContext
{
    private readonly IConfiguration configuration;
    
    // Tables 
    public DbSet<Service> Services { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Job> Jobs { get; set; }
    
    public ServiceDbContext(
        DbContextOptions<ServiceDbContext> options, 
        IConfiguration configuration) 
        : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = 
            this.configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite(connectionString);
    }
}