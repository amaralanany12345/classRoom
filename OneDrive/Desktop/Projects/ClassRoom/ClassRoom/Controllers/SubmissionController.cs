using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly SubmissionService _submissionService;

        public SubmissionController(SubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        [HttpPost]
        public async Task<ActionResult<Submission>> submitAssignment([FromForm] FileUploadModel uploadedFile, int studentId, int assignmentId)
        {
            return Ok(await _submissionService.submitAssignment(studentId, assignmentId, uploadedFile));
        }

        [HttpDelete]

        public async Task<ActionResult> deleteSubmissionOfAssignment(int studentId, int assignmentId)
        {
            await _submissionService.deleteSubmissionOfAssignment(studentId, assignmentId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Submission>> getStudentSubmitAssignment(int studentId, int assignmentId)
        {
            return Ok(await _submissionService.getStudentSubmitAssignment(studentId, assignmentId));
        }

    }
}
