using System.ComponentModel.DataAnnotations;

namespace Telesure.WordPlay.Core.Models.Employee
{
    public abstract class BaseEmployeeDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Designation { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }

    }
}
