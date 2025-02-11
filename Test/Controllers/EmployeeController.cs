using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Reposatries.Employee_Repository;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employee;

        public EmployeeController(IEmployeeRepository employee )
        {
            this.employee = employee;
        }
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {
            return Ok(await employee.GetAllEmployees());
        }

        [HttpGet("GetEmployee/{Id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var employee = await this.employee.GetEmployee(Id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }
            else
            {
                return Ok(employee);
            }
               
        }

        [HttpDelete("DeleteEmployee/{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            bool result = await employee.DeleteEmployee(Id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Employee Not Found");
        }

        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try
            {
                await this.employee.InsertEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { Id = employee.Id }, employee);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while inserting the employee.");
            }
           
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await this.employee.UpdateEmployee(employee);
                return Ok(new { message = "Employee Updates Successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!!!!!!! Updating Employee{ex.Message}");
                return StatusCode(500, new { message = "An Error ocurred while updating the employee." });
            }
        }

    }
}
