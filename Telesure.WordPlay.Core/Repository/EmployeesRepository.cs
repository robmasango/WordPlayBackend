using AutoMapper;
using Telesure.WordPlay.Core.Contracts;
using Telesure.WordPlay.Data;

namespace Telesure.WordPlay.Core.Repository
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(WordPlayDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
