using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/workFlow")]
    public class WorkFlowServiceController : ControllerBase
    {
        private readonly IWorkFlowStageService _workFlowStageService;
        public WorkFlowServiceController(IWorkFlowStageService workFlowStageService)
        {
            _workFlowStageService = workFlowStageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _workFlowStageService.GetAllStagesAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var program = await _workFlowStageService.GetStageByNameAsync(id.ToString());
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(WorkFlowStage stage)
        {
            var createdProgram = await _workFlowStageService.CreateStageAsync(stage);
            return Ok(createdProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(string stageName, WorkFlowStage stage)
        {
            var updatedProgram = await _workFlowStageService.UpdateStageAsync(stageName, stage);
            if (updatedProgram == null)
            {
                return NotFound();
            }
            return Ok(updatedProgram);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var success = await _workFlowStageService.DeleteStageAsync(id.ToString());
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
