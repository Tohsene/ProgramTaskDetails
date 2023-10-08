using Microsoft.Azure.Cosmos;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class CosmosDbContext
    {
        private readonly Container _container;

        public CosmosDbContext(CosmosDbSettings cosmosDbSettings)
        {
            var cosmosClient = new CosmosClient(cosmosDbSettings.EndpointUri, cosmosDbSettings.PrimaryKey);
            var database = cosmosClient.GetDatabase(cosmosDbSettings.DatabaseName);
            _container = database.GetContainer(cosmosDbSettings.ContainerName);
        }

        public async Task<ApplicationFormModel> CreateAsync(ApplicationFormModel applicationForm)
        {
            var response = await _container.CreateItemAsync(applicationForm);
            return response.Resource;
        }

        public async Task<ApplicationFormModel> GetByIdAsync(string id)
        {
            var response = await _container.ReadItemAsync<ApplicationFormModel>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<List<ApplicationFormModel>> GetAllAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var results = new List<ApplicationFormModel>();

            var resultSetIterator = _container.GetItemQueryIterator<ApplicationFormModel>(query);
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<ApplicationFormModel> UpdateAsync(int id, ApplicationFormModel updatedForm)
        {
            var response = await _container.UpsertItemAsync(updatedForm, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _container.DeleteItemAsync<ApplicationFormModel>(id, new PartitionKey(id));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public class CosmosDbSettings
        {
            public string EndpointUri { get; set; }
            public string PrimaryKey { get; set; }
            public string DatabaseName { get; set; }
            public string ContainerName { get; set; }
        }

        public async Task<List<ProgramDetailsModel>> GetAllProgramsAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var results = new List<ProgramDetailsModel>();

            var resultSetIterator = _container.GetItemQueryIterator<ProgramDetailsModel>(query);
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<ProgramDetailsModel> GetProgramByIdAsync(int id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ProgramDetailsModel>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Return null if the item is not found.
            }
        }

        public async Task<ProgramDetailsModel> CreateProgramAsync(ProgramDetailsDto programDetailsDto)
        {
            var program = new ProgramDetailsModel
            {
                Id = GenerateUniqueId(), // You may need a unique ID generation method.
                ProgramTitle = programDetailsDto.ProgramTitle,
                ProgramSummary = programDetailsDto.ProgramSummary,
                ProgramDescription = programDetailsDto.ProgramDescription,
                MinQualification = programDetailsDto.MinQualification,
                ProgramType = programDetailsDto.ProgramType,

                // Map other properties similarly.
            };

            var response = await _container.CreateItemAsync(program);
            return response.Resource;
        }

        public async Task<ProgramDetailsModel> UpdateProgramAsync(int id, ProgramDetailsDto programDetailsDto)
        {
            var existingProgram = await GetProgramByIdAsync(id);

            if (existingProgram != null)
            {
                // Update properties of the existing program with the new values from programDetailsDto.
                existingProgram.ProgramTitle = programDetailsDto.ProgramTitle;
                existingProgram.ProgramSummary = programDetailsDto.ProgramSummary;
                existingProgram.NumOfApplications = programDetailsDto.NumOfApplications;
                existingProgram.ProgramBenefits = programDetailsDto.ProgramBenefits;
                existingProgram.ProgramDescription = programDetailsDto.ProgramDescription;
                existingProgram.ProgramLocation = programDetailsDto.ProgramLocation;
                existingProgram.ProgramSkills = programDetailsDto.ProgramSkills;
                existingProgram.ProgramStart = programDetailsDto.ProgramStart;
                existingProgram.MinQualification = programDetailsDto.MinQualification;
                existingProgram.ProgramType = programDetailsDto.ProgramType;



                var response = await _container.ReplaceItemAsync(existingProgram, existingProgram.Id.ToString());
                return response.Resource;
            }

            return null;
        }

        public async Task<bool> DeleteProgramAsync(int id)
        {
            var existingProgram = await GetProgramByIdAsync(id);

            if (existingProgram != null)
            {
                var response = await _container.DeleteItemAsync<ProgramDetailsModel>(id.ToString(), new PartitionKey(id.ToString()));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }

            return false;
        }

        // You may need a method to generate a unique ID for new programs.
        private int GenerateUniqueId()
        {
            return Guid.NewGuid().GetHashCode();
        }

        public async Task<List<WorkFlowStage>> GetAllStagesAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var stages = new List<WorkFlowStage>();

            var resultSetIterator = _container.GetItemQueryIterator<WorkFlowStage>(query);
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                stages.AddRange(response);
            }

            return stages;
        }

        public async Task<WorkFlowStage> GetStageByNameAsync(string stageName)
        {
            try
            {
                var response = await _container.ReadItemAsync<WorkFlowStage>(stageName, new PartitionKey(stageName));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Return null if the item is not found.
            }
        }

        public async Task<WorkFlowStage> CreateStageAsync(WorkFlowStage stage)
        {
            var response = await _container.CreateItemAsync(stage);
            return response.Resource;
        }

        public async Task<WorkFlowStage> UpdateStageAsync(string stageName, WorkFlowStage stage)
        {
            var existingStage = await GetStageByNameAsync(stageName);

            if (existingStage != null)
            {
                stage.StageName = stageName; // Ensure that the stage name is not changed.
                var response = await _container.ReplaceItemAsync(stage, stageName);
                return response.Resource;
            }

            return null; // Indicate that the item wasn't found.
        }

        public async Task<bool> DeleteStageAsync(string stageName)
        {
            var existingStage = await GetStageByNameAsync(stageName);

            if (existingStage != null)
            {
                var response = await _container.DeleteItemAsync<WorkFlowStage>(stageName, new PartitionKey(stageName));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }

            return false; // Indicate that the item wasn't found.
        }
    }
}
