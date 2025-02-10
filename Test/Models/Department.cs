namespace Test.Models
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Manager { get; set; }
        public List<Employee> ? Employees { get; set; }
    }
}
