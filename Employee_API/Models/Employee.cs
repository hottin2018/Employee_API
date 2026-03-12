using System.ComponentModel.DataAnnotations;

namespace Employee_API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(32,MinimumLength = 5,ErrorMessage ="Name is required")]
        public string Name { get; set; } = "";
        [Required]
        [Range(18,58,ErrorMessage ="Age should be between 18 and 58")]
        public int Age { get; set; }
    }
}
