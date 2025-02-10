using Microsoft.EntityFrameworkCore;
using Test.DTOs;
using Test.Models;

namespace Test.Reposatries.Employee_Reposatiry
{
    public class EmployeeReposatiry : IEmployeeReposatiry
    {
        //Dependence Injection
        private readonly MyContext context;

        private Employee employee = new Employee();

        //Constructor
        public EmployeeReposatiry(MyContext context)
        {
            this.context = context;
        }


        //Get All Employees
        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            return await context.Employees.Include(d => d.Department).Select(e => new EmployeeDto { Id = e.Id, Name = e.Name, Address = e.Address, Age = e.Age, Department_Manager = e.Department != null ? e.Department.Manager : "No Department", Salary = e.Salary, Department_Name = e.Department != null ? e.Department.Name : "No Department" }).ToListAsync();
        }

        //Get Specific Employees
        public async Task<Employee> GetEmployee(int Id)
        {
            employee = await context.Employees.SingleOrDefaultAsync(Emp => Emp.Id == Id);
            return employee;
        }

        //Inser An Employee
        public async Task InsertEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        //Update An Employee
        public async Task UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        //Delete An Employee
        public async Task<bool> DeleteEmployee(int Id)
        {
            employee = await GetEmployee(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
                return true;
            }
            return false;

        }

    }
}
