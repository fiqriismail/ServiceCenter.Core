using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Services;

public interface IJobRepository
{
    IQueryable<Job> SelectJobs();
    ValueTask<Job> SelectJobAsync(Guid id);
    ValueTask<Job> InsertJobAsync(Job job);
    ValueTask<Job> UpdateJobAsync(Job job);
    ValueTask<Job> DeleteJobAsync(Job job);
}