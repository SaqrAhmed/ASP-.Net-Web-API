using System.ComponentModel.DataAnnotations;

namespace Test.DTOs
{
    public class RegistartionDto
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String ConfirmPassword { get; set; }
        public String Email { get; set; }
    }
}
