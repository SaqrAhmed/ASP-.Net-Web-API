using Test.Models;

namespace Test.Reposatries.Department_Reposatiry
{
    public interface IDepartmentReposatiry
    {
        Task<bool> DeleteDepartment(int Id);
        Task<List<Department>> GetAllDeparments();
        Task<Department> GetDepartment(int Id);
        Task InsertDepartment(Department department);
        Task UpdateDepartment(Department department);
    }
}