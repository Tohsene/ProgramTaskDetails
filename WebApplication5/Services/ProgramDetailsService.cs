using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class ProgramDetailsService : IProgramDetailsService
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public ProgramDetailsService(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }
        public Task<ProgramDetailsModel> CreateProgramAsync(ProgramDetailsDto programDetailsDto)
        {
            return _cosmosDbContext.CreateProgramAsync(programDetailsDto);
        }

        public async Task<bool> DeleteProgramAsync(int id)
        {
            try
            {
                var existingForm = await _cosmosDbContext.GetProgramByIdAsync(id);
                if (existingForm != null)
                {
                    await _cosmosDbContext.DeleteProgramAsync(id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<ProgramDetailsModel>> GetAllProgramsAsync()
        {
            try
            {
                var forms = await _cosmosDbContext.GetAllProgramsAsync();
                return forms;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProgramDetailsModel> GetProgramByIdAsync(int id)
        {
            try
            {
                var form = await _cosmosDbContext.GetProgramByIdAsync(id);
                return form;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProgramDetailsModel> UpdateProgramAsync(int id, ProgramDetailsDto programDetailsDto)
        {
            try
            {
                var existingForm = await _cosmosDbContext.GetProgramByIdAsync(id);
                if (existingForm != null)
                {

                    existingForm.ProgramTitle = programDetailsDto.ProgramTitle;
                    existingForm.ProgramType = programDetailsDto.ProgramType;
                    existingForm.ApplicationOpen = programDetailsDto.ApplicationOpen;
                    existingForm.ProgramStart = programDetailsDto.ProgramStart;
                    existingForm.ProgramBenefits = programDetailsDto.ProgramBenefits;
                    existingForm.MinQualification = programDetailsDto.MinQualification;
                    existingForm.NumOfApplications = programDetailsDto.NumOfApplications;
                    existingForm.ProgramLocation = programDetailsDto.ProgramLocation;



                    await _cosmosDbContext.UpdateProgramAsync(id, existingForm);

                    return existingForm;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
