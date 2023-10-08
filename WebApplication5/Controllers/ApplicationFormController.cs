using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/ApplicationForm")]
    public class ApplicationFormController : ControllerBase
    {
        private readonly ApplicationFormInterface _applicationFormInterface;
        public ApplicationFormController(ApplicationFormInterface applicationFormInterface)
        {
            _applicationFormInterface = applicationFormInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var programs = await _applicationFormInterface.GetAllAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var program = await _applicationFormInterface.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ApplicationFormModel applicationForm)
        {
            var createdProgram = await _applicationFormInterface.CreateAsync(applicationForm);
            return Ok(createdProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, ApplicationFormModel applicationForm)
        {
            var updatedProgram = await _applicationFormInterface.UpdateAsync(id, applicationForm);
            if (updatedProgram == null)
            {
                return NotFound();
            }
            return Ok(updatedProgram);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var success = await _applicationFormInterface.DeleteAsync(id);
            return NoContent();
        }
    }
}
