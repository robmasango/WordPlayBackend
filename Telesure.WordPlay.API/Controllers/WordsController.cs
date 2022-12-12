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

namespace Telesure.WordPlay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsRepository _WordsRepository;
        private readonly IWordTypesRepository _wordTypeRepository;
        private readonly IMapper _mapper;

        public WordsController(IWordsRepository WordsRepository, IWordTypesRepository WordTypesRepository, IMapper mapper)
        {
            this._WordsRepository = WordsRepository;
            this._wordTypeRepository = WordTypesRepository;
            this._mapper = mapper;
        }

        // GET: api/Words
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetWordDto>>> GetWords()
        {
            try
            {
                var WordTypes = await _WordsRepository.GetAllAsync();
                var records = _mapper.Map<List<WordDto>>(WordTypes);
                return Ok(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Words/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<WordDto>>> GetPagedWords([FromQuery] QueryParameters queryParameters)
{
            var pagedWordsResult = await _WordsRepository.GetAllAsync<WordDto>(queryParameters);
            return Ok(pagedWordsResult);
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WordDto>> GetWord(int id)
        {
            var Word = await _WordsRepository.GetAsync<WordDto>(id);
            return Ok(Word);
        }

        [HttpGet("GetWordByWordType/{name}")]
        public async Task<ActionResult<WordDto>> GetWordByWordType(string name)
        {
            var wordtype = await _wordTypeRepository.GetWordTypesByName(name);
            if(wordtype == null)
            {
                return BadRequest();
            }
            else
            {
                var Words = await _WordsRepository.GetWordsByWordTypeId(wordtype.Id);
                return Ok(Words);
            }

        }


        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, WordDto WordDto)
        {
            try
            {
                await _WordsRepository.UpdateAsync(id, WordDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WordExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WordDto>> PostWord(CreateWordDto WordDto)
        {
            var Word = await _WordsRepository.AddAsync<CreateWordDto, WordDto>(WordDto);
            return CreatedAtAction(nameof(GetWord), new { id = Word.Id }, Word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            await _WordsRepository.DeleteAsync(id); 
            return NoContent();
        }

        private async Task<bool> WordExists(int id)
        {
            return await _WordsRepository.Exists(id);
        }
    }
}
