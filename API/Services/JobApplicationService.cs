using API.Database;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly CrmContext _context;

        public JobApplicationService(CrmContext context)
        {
            _context = context;
        }

        public async Task<JobApplicationDTO> GetJobApplicationByIdAsync(int jobId)
        {
            var application = await _context.Set<JobApplication>().SingleAsync(x => x.Id == jobId);

            var mappedApplication = new JobApplicationDTO()
            {
                Id = application.Id,
                UserId = application.UserId,
                Company = application.Company,
                Notes = application.Notes,
                ApplicationURL = application.ApplicationURL,
                isActive = application.isActive
            };

            return mappedApplication;
        }

        public async Task<bool> CreateJobApplicationAsync(JobApplicationDTO jobApplicationDTO)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Add(new JobApplication()
                        {
                            UserId = jobApplicationDTO.UserId,
                            Company = jobApplicationDTO.Company,
                            Notes = jobApplicationDTO.Notes,
                            ApplicationURL = jobApplicationDTO.ApplicationURL,
                            isActive = true,
                        });

                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task UpdateJobApplicationAsync(JobApplicationUpdateRequestDTO jobApplicationUpdateRequest)
        {
            var application = await _context.Set<JobApplication>().SingleAsync(x => x.UserId == jobApplicationUpdateRequest.UserId
                                                                                     && x.Id == jobApplicationUpdateRequest.Id);

            if (application == null)
            {
                return;
            }

            application.Company = jobApplicationUpdateRequest.Company;
            application.Notes = jobApplicationUpdateRequest.Notes;
            application.ApplicationURL = jobApplicationUpdateRequest.ApplicationURL;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobApplicationAsync(int jobId)
        {
            try
            {
                using ( var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var application = await _context.Set<JobApplication>()
                                                .Include(x => x.ApplicationLogs)
                                                .SingleAsync();

                        _context.Attach(application.ApplicationLogs);
                        _context.Remove(application);

                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex);
                        transaction.Rollback();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<List<JobApplicationDTO>> GetJobApplicationsByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task ToggleJobApplicationAsync(int jobId)
        {
            var application = await _context.Set<JobApplication>().SingleAsync(x => x.Id == jobId);
            application.isActive = !application.isActive;

            await _context.SaveChangesAsync();
        }
    }
}
