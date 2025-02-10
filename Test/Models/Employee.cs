using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Test.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
    
        public Department ? Department { get; set; }
    }
}
