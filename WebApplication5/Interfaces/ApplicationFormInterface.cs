using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface ApplicationFormInterface
    {
        Task<ApplicationFormModel> CreateAsync(ApplicationFormModel applicationForm);
        Task<ApplicationFormModel> GetByIdAsync(string id);
        Task<List<ApplicationFormModel>> GetAllAsync();
        Task<ApplicationFormModel> UpdateAsync(string id, ApplicationFormModel applicationForm);
        Task<int> DeleteAsync(string id);
    }
}
