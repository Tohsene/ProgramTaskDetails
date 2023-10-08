using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IWorkFlowStageService
    {
        Task<List<WorkFlowStage>> GetAllStagesAsync();
        Task<WorkFlowStage> GetStageByNameAsync(string stageName);
        Task<WorkFlowStage> CreateStageAsync(WorkFlowStage stage);
        Task<WorkFlowStage> UpdateStageAsync(string stageName, WorkFlowStage stage);
        Task<bool> DeleteStageAsync(string stageName);
    }
}
