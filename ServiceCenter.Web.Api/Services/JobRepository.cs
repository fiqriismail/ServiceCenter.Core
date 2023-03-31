using Microsoft.EntityFrameworkCore;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public class JobRepository : IJobRepository
{
    private readonly ServiceDbContext context;


    public JobRepository(ServiceDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Job> SelectJobs()
    {
        return this.context.Jobs.AsQueryable();
    }

    public async ValueTask<Job> SelectJobAsync(Guid id)
    {
        return await this.context.Jobs.FindAsync(id);
    }

    public async ValueTask<Job> InsertJobAsync(Job job)
    {
        job.Id = Guid.NewGuid();

        await this.context.Jobs.AddAsync(job);
        await this.context.SaveChangesAsync();

        return job;
    }

    public async ValueTask<Job> UpdateJobAsync(Job job)
    {
        this.context.Entry(job).State = EntityState.Modified;
        await this.context.SaveChangesAsync();

        return job;
    }

    public async ValueTask<Job> DeleteJobAsync(Job job)
    {
        this.context.Entry(job).State = EntityState.Deleted;
        await this.context.SaveChangesAsync();

        return job;
    }
}