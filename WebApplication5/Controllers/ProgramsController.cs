using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/programs")]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramDetailsService _programService;

        public ProgramsController(IProgramDetailsService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programService.GetAllProgramsAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var program = await _programService.GetProgramByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(ProgramDetailsDto programDetailsDto)
        {
            var createdProgram = await _programService.CreateProgramAsync(programDetailsDto);
            return CreatedAtAction(nameof(GetProgramById), new { id = createdProgram.Id }, createdProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(int id, ProgramDetailsDto programDetailsDto)
        {
            var updatedProgram = await _programService.UpdateProgramAsync(id, programDetailsDto);
            if (updatedProgram == null)
            {
                return NotFound();
            }
            return Ok(updatedProgram);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var success = await _programService.DeleteProgramAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
