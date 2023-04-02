using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ServiceCenter.Web.Api.Database;

public class UsersContext : IdentityUserContext<IdentityUser>
{
    private readonly IConfiguration configuration;
    
    public UsersContext(DbContextOptions<UsersContext> options, 
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