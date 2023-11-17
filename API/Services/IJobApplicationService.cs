using API.DTOs;

namespace API.Services
{
    public interface IJobApplicationService
    {
        Task<JobApplicationDTO> GetJobApplicationByIdAsync(int jobId);
        Task<List<JobApplicationDTO>> GetJobApplicationsByUserAsync(int userId);
        Task ToggleJobApplicationAsync(int jobId);
        Task<bool> CreateJobApplicationAsync(JobApplicationDTO jobApplicationDTO);
        Task DeleteJobApplicationAsync (int jobId);
        Task UpdateJobApplicationAsync (JobApplicationUpdateRequestDTO jobApplicationDTO);
    }
}
