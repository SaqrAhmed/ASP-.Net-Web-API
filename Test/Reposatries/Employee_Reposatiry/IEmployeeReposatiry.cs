using Microsoft.AspNetCore.Mvc;
using Test.DTOs;
using Test.Models;

namespace Test.Reposatries.Employee_Reposatiry
{
    public interface IEmployeeReposatiry
    {
        Task<bool> DeleteEmployee(int Id);
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<Employee> GetEmployee(int Id);
        Task InsertEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);

    }
}