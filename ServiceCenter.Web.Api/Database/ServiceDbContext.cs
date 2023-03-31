using Microsoft.EntityFrameworkCore;

namespace ServiceCenter.Web.Api.Database;

public class ServiceDbContext : DbContext
{
    private readonly IConfiguration configuration;
    
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