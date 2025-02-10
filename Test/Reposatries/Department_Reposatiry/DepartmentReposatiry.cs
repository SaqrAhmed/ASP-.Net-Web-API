using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Reposatries.Department_Reposatiry
{
    public class DepartmentReposatiry : IDepartmentReposatiry
    {
        private readonly MyContext context;
        private Department? department;

        public DepartmentReposatiry(MyContext context)
        {
            this.context = context;
        }
        //Get All Departments
        public async Task<List<Department>> GetAllDeparments()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            return await context.Employees
                .Where(e => e.DeptId == departmentId)
                .ToListAsync();
        }


        //Get Department By Id
        public async Task<Department> GetDepartment(int Id)
        {
            return await context.Departments.Include(d => d.Employees ).SingleOrDefaultAsync(x => x.Id == Id);
        }

        //Create New Department
        public async Task InsertDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            context.Departments.Add(department);
            await context.SaveChangesAsync();
        }

        //Update Department 
        public async Task UpdateDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            context.Departments.Update(department);
            await context.SaveChangesAsync();
        }

        //Delete Department 
        public async Task<bool> DeleteDepartment(int Id)
        {
            this.department = await GetDepartment(Id);
            if (department == null)
            {
                return false;
            }
            context.Departments.Remove(department);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
