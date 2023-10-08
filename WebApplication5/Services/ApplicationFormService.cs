using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class ApplicationFormService : ApplicationFormInterface
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public ApplicationFormService(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public Task<ApplicationFormModel> CreateAsync(ApplicationFormModel applicationForm)
        {
            return _cosmosDbContext.CreateAsync(applicationForm);
        }

        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                var existingForm = await _cosmosDbContext.GetByIdAsync(id);
                if (existingForm != null)
                {
                    await _cosmosDbContext.DeleteAsync(id);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<ApplicationFormModel>> GetAllAsync()
        {
            try
            {
                var forms = await _cosmosDbContext.GetAllAsync();
                return forms;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ApplicationFormModel> GetByIdAsync(string id)
        {
            try
            {
                var form = await _cosmosDbContext.GetByIdAsync(id);
                return form;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ApplicationFormModel> UpdateAsync(string id, ApplicationFormModel applicationForm)
        {
            try
            {
                var existingForm = await _cosmosDbContext.GetByIdAsync(id);
                if (existingForm != null)
                {

                    existingForm.CoverImage = applicationForm.CoverImage;
                    existingForm.PersonalInformation = applicationForm.PersonalInformation;
                    existingForm.Profile = applicationForm.Profile;
                    existingForm.AdditionQuestion = applicationForm.AdditionQuestion;


                    await _cosmosDbContext.UpdateAsync(int.Parse(id), existingForm);

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
