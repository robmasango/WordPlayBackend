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
using Telesure.WordPlay.Core.Models.Sentence;

namespace Telesure.WordPlay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentencesController : ControllerBase
    {
        private readonly ISentencesRepository _SentencesRepository;
        private readonly IMapper _mapper;

        public SentencesController(ISentencesRepository SentencesRepository, IMapper mapper)
        {
            this._SentencesRepository = SentencesRepository;
            this._mapper = mapper;
        }

        // GET: api/Sentences
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetSentenceDto>>> GetWords()
        {
            try
            {
                var Sentences = await _SentencesRepository.GetAllAsync();
                var records = _mapper.Map<List<SentenceDto>>(Sentences);
                return Ok(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Sentences/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<SentenceDto>>> GetPagedSentences([FromQuery] QueryParameters queryParameters)
{
            var pagedSentencesResult = await _SentencesRepository.GetAllAsync<SentenceDto>(queryParameters);
            return Ok(pagedSentencesResult);
        }

        // GET: api/Sentences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SentenceDto>> GetSentence(int id)
        {
            var Sentence = await _SentencesRepository.GetAsync<SentenceDto>(id);
            return Ok(Sentence);
        }

        // PUT: api/Sentences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSentence(int id, SentenceDto SentenceDto)
        {
            try
            {
                await _SentencesRepository.UpdateAsync(id, SentenceDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SentenceExists(id))
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

        // POST: api/Sentences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SentenceDto>> PostSentence(CreateSentenceDto SentenceDto)
        {
            var Sentence = await _SentencesRepository.AddAsync<CreateSentenceDto, SentenceDto>(SentenceDto);
            return CreatedAtAction(nameof(GetSentence), new { id = Sentence.Id }, Sentence);
        }

        // DELETE: api/Sentences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSentence(int id)
        {
            await _SentencesRepository.DeleteAsync(id); 
            return NoContent();
        }

        private async Task<bool> SentenceExists(int id)
        {
            return await _SentencesRepository.Exists(id);
        }
    }
}
