using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Reposatries.Department_Reposatiry;
namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentReposatiry department;

        public DepartmentController(IDepartmentReposatiry department)
        {
            this.department = department;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await department.GetAllDeparments());
        }

        [HttpGet("GetDepartment/{Id}")]
        public async Task<IActionResult> GetDepartment(int Id)
        {
            var department = await this.department.GetDepartment(Id);
            if (department == null)
            {
                return NotFound("Department Not Found");
            }
            else
            {
                return Ok(department);
            }

        }

        [HttpDelete("DeleteDepartment/{Id}")]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            bool result = await department.DeleteDepartment(Id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Department Not Found");
        }

        [HttpPost("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await this.department.InsertDepartment(department);
                return CreatedAtAction(nameof(GetDepartment), new { Id = department.Id }, department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while inserting the Department.");
            }

        }

        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await this.department.UpdateDepartment(department);
                return Ok(new { message = "Department Updates Successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!!!!!!! Updating Department{ex.Message}");
                return StatusCode(500, new { message = "An Error ocurred while updating the Department." });
            }
        }



    }
}
