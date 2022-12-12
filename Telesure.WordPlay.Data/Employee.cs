using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? PhoneNumber { get; set; }     
    }
}
