using Test.DTOs;
using Test.Models;

namespace Test.Reposatries.Employee_Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> DeleteEmployee(int Id);
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<Employee> GetEmployee(int Id);
        Task InsertEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);

    }
}