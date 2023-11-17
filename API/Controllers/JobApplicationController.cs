using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/v1.0/[controller]")]
    public class JobApplicationController : ControllerBase
    {
        private IJobApplicationService _jobApplicationService;
        
        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        /// <summary>
        /// Fetch a JobApplication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult<JobApplicationDTO>> Get(int id)
        {
            return await _jobApplicationService.GetJobApplicationByIdAsync(id);
        }

        /// <summary>
        /// Update a JobApplication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("id")]
        public async Task<IActionResult> Post([FromBody] JobApplicationUpdateRequestDTO request)
        {
            await _jobApplicationService.UpdateJobApplicationAsync(request);
            return Ok();
        }

        /// <summary>
        /// Delete a JobApplication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobApplicationService.DeleteJobApplicationAsync(id);
            return Ok();
        }

        /// <summary>
        /// Toggle a JobApplication to active/inactive
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> ToggleApplication(int id)
        {
            await _jobApplicationService.ToggleJobApplicationAsync(id);
            return Ok();
        }
    }
}
