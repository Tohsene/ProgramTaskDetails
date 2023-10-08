using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IProgramDetailsService
    {
        Task<List<ProgramDetailsModel>> GetAllProgramsAsync();
        Task<ProgramDetailsModel> GetProgramByIdAsync(int id);
        Task<ProgramDetailsModel> CreateProgramAsync(ProgramDetailsDto programDetailsDto);
        Task<ProgramDetailsModel> UpdateProgramAsync(int id, ProgramDetailsDto programDetailsDto);
        Task<bool> DeleteProgramAsync(int id);
    }
}
