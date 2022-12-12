using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Core.Models.Employee
{
    public class GetEmployeeDto : BaseEmployeeDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
