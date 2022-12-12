using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telesure.WordPlay.Data;
using Telesure.WordPlay.Core.Contracts;
using AutoMapper;
using Telesure.WordPlay.Core.Models.Word;
using Microsoft.AspNetCore.Authorization;
using Telesure.WordPlay.Core.Models.WordType;
using Telesure.WordPlay.Core.Models;
using Telesure.WordPlay.Core.Repository;
using Telesure.WordPlay.Core.Models.Employee;

namespace Telesure.WordPlay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _EmployeesRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesRepository EmployeesRepository, IMapper mapper)
        {
            this._EmployeesRepository = EmployeesRepository;
            this._mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetWords()
        {
            try
            {
                var Employees = await _EmployeesRepository.GetAllAsync();
                var records = _mapper.Map<List<EmployeeDto>>(Employees);
                return Ok(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Employees/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<EmployeeDto>>> GetPagedEmployees([FromQuery] QueryParameters queryParameters)
{
            var pagedEmployeesResult = await _EmployeesRepository.GetAllAsync<EmployeeDto>(queryParameters);
            return Ok(pagedEmployeesResult);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var Employee = await _EmployeesRepository.GetAsync<EmployeeDto>(id);
            return Ok(Employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDto EmployeeDto)
        {
            try
            {
                await _EmployeesRepository.UpdateAsync(id, EmployeeDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(CreateEmployeeDto EmployeeDto)
        {
            var Employee = await _EmployeesRepository.AddAsync<CreateEmployeeDto, EmployeeDto>(EmployeeDto);
            return CreatedAtAction(nameof(GetEmployee), new { id = Employee.Id }, Employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _EmployeesRepository.DeleteAsync(id); 
            return NoContent();
        }

        private async Task<bool> EmployeeExists(int id)
        {
            return await _EmployeesRepository.Exists(id);
        }
    }
}
