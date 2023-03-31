using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;
using ServiceCenter.Web.Api.Services;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
   private readonly IEmployeeRepository employeeRepository;


   public EmployeesController(IEmployeeRepository employeeRepository)
   {
      this.employeeRepository = employeeRepository;
   }
   
   [HttpGet]
   public IActionResult GetEmployees()
   {
      var employeeQuery = this.employeeRepository.SelectEmployees();
      var employees = employeeQuery.ToList();
      
      return Ok(employees);
   }
   
   [HttpGet("{id}")]
   public async ValueTask<IActionResult> GetEmployee(Guid id)
   {
      var employee = await this.employeeRepository.SelectEmployeeAsync(id);
      
      if (employee is null)
      {
         return NotFound();
      }
      
      return Ok(employee);
   }

   [HttpPost]
   public async ValueTask<IActionResult> PostEmployee([FromBody] Employee employee)
   {
      if (employee is null)
      {
         return BadRequest();
      }

      var newEmployee = await this.employeeRepository.InsertEmployeeAsync(employee);
      
      return CreatedAtAction(nameof(GetEmployees), 
         new { id = newEmployee.Id }, newEmployee);
   }
   
   [HttpPut]
   public async ValueTask<IActionResult> PutEmployee([FromBody] Employee employee)
   {
      var existingEmployee = await this.employeeRepository.SelectEmployeeAsync(employee.Id);
      
      if (existingEmployee is null)
      {
         return NotFound();
      }

      var updatedEmployee = await this.employeeRepository.UpdateEmployeeAsync(employee);
      
      return Ok(updatedEmployee);
   }
   
   [HttpDelete("{id}")]
   public async ValueTask<IActionResult> DeleteEmployee(Guid id)
   {
      var employee = await this.employeeRepository.SelectEmployeeAsync(id);
      
      if (employee is null)
      {
         return NotFound();
      }

      var deletedEmployee = await this.employeeRepository.DeleteEmployeeAsync(employee);
      
      return Ok(deletedEmployee);
   }
   
   
}