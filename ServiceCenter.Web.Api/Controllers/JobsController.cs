using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;
using ServiceCenter.Web.Api.Services;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobRepository jobRepository;
    
    public JobsController(IJobRepository jobRepository)
    {
        this.jobRepository = jobRepository;
    }
    
    [HttpGet]
    public IActionResult GetJobs()
    {
        var jobQuery = this.jobRepository.SelectJobs();
        var jobs = jobQuery.ToList();
        
        return Ok(jobs);
    }
    
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetJob(Guid id)
    {
        var job = await this.jobRepository.SelectJobAsync(id);
        
        if (job is null)
        {
            return NotFound();
        }
        
        return Ok(job);
    }
    
    [HttpPost]
    public async ValueTask<IActionResult> PostJob([FromBody] Job job)
    {
        if (job is null)
        {
            return BadRequest();
        }
        
        var newJob = await this.jobRepository.InsertJobAsync(job);
        
        return CreatedAtAction(nameof(GetJobs), 
            new { id = newJob.Id }, newJob);
    }
    
    [HttpPut]
    public async ValueTask<IActionResult> PutJob([FromBody] Job job)
    {
        var existingJob = await this.jobRepository.SelectJobAsync(job.Id);
        
        if (existingJob is null)
        {
            return NotFound();
        }
        
        var updatedJob = await this.jobRepository.UpdateJobAsync(job);
        
        return Ok(updatedJob);
    }
    
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteJob(Guid id)
    {
        var job = await this.jobRepository.SelectJobAsync(id);
        
        if (job is null)
        {
            return NotFound();
        }
        
        await this.jobRepository.DeleteJobAsync(job);
        
        return NoContent();
    }
}