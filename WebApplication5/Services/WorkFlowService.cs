using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Services
{
        public class WorkFlowService : IWorkFlowStageService
        {
            private readonly CosmosDbContext _cosmosDbContext;

            public WorkFlowService(CosmosDbContext cosmosDbContext)
            {
                _cosmosDbContext = cosmosDbContext;
            }
            public async Task<WorkFlowStage> CreateStageAsync(WorkFlowStage stage)
            {
                try
                {
                    return await _cosmosDbContext.CreateStageAsync(stage);
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log errors as needed.
                    throw;
                }
            }

            public async Task<bool> DeleteStageAsync(string stageName)
            {
                try
                {
                    return await _cosmosDbContext.DeleteStageAsync(stageName);
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log errors as needed.
                    throw;
                }
            }

            public async Task<List<WorkFlowStage>> GetAllStagesAsync()
            {
                try
                {
                    return await _cosmosDbContext.GetAllStagesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            public async Task<WorkFlowStage> GetStageByNameAsync(string stageName)
            {
                try
                {
                    return await _cosmosDbContext.GetStageByNameAsync(stageName);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            public async Task<WorkFlowStage> UpdateStageAsync(string stageName, WorkFlowStage stage)
            {
                try
                {
                    return await _cosmosDbContext.UpdateStageAsync(stageName, stage);
                }
                catch (Exception ex)
                {
                    // Handle exceptions and log errors as needed.
                    throw;
                }
            }
        }
    }

