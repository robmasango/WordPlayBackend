using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telesure.WordPlay.Data;
using Telesure.WordPlay.Core.Models.WordType;
using AutoMapper;
using Telesure.WordPlay.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Telesure.WordPlay.Core.Exceptions;
using Microsoft.AspNetCore.OData.Query;

namespace Telesure.WordPlay.API.Controllers
{
    [Route("api/[controller]")]
    public class WordTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWordTypesRepository _WordTypesRepository;
        private readonly ILogger<WordTypesController> _logger;

        public WordTypesController(IMapper mapper, IWordTypesRepository WordTypesRepository, ILogger<WordTypesController> logger)
        {
            this._mapper = mapper;
            this._WordTypesRepository = WordTypesRepository;
            this._logger = logger;
        }

        // GET: api/WordTypes
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetWordTypeDto>>> GetWordTypes()
        {
            var WordTypes = await _WordTypesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetWordTypeDto>>(WordTypes);
            return Ok(records);
        }

        // GET: api/WordTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WordTypeDto>> GetWordType(int id)
        {
            var WordType = await _WordTypesRepository.GetDetails(id);

            if (WordType == null)
            {
                throw new NotFoundException(nameof(GetWordType), id);
            }

            var WordTypeDto = _mapper.Map<WordTypeDto>(WordType);

            return Ok(WordTypeDto);
        }

        // PUT: api/WordTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWordType(int id, UpdateWordTypeDto updateWordTypeDto)
        {
            if (id != updateWordTypeDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var WordType = await _WordTypesRepository.GetAsync(id);

            if (WordType == null)
            {
                throw new NotFoundException(nameof(GetWordTypes), id);
            }

            _mapper.Map(updateWordTypeDto, WordType);

            try
            {
                await _WordTypesRepository.UpdateAsync(WordType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WordTypeExists(id))
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

        // POST: api/WordTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WordType>> PostWordType(CreateWordTypeDto createWordTypeDto)
        {
            var WordType = _mapper.Map<WordType>(createWordTypeDto);

            await _WordTypesRepository.AddAsync(WordType);

            return CreatedAtAction("GetWordType", new { id = WordType.Id }, WordType);
        }

        // DELETE: api/WordTypes/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> DeleteWordType(int id)
        {
            var WordType = await _WordTypesRepository.GetAsync(id);
            if (WordType == null)
            {
                throw new NotFoundException(nameof(GetWordTypes), id);
            }

            await _WordTypesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WordTypeExists(int id)
        {
            return await _WordTypesRepository.Exists(id);
        }
    }
}
