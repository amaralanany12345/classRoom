using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService _assignmentService;

        public AssignmentController(AssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Assignment>> createAssignment(string title, string description, int score, int classRoomId)
        {
            return Ok(await _assignmentService.addAssignment(title, description, score, classRoomId));
        }

        [HttpGet]
        public async Task<ActionResult<Assignment>> getAssignment(int assignmentId)
        {
            return Ok(await _assignmentService.GetAssignment(assignmentId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteAssignment(int assignmentId)
        {
            await _assignmentService.removeAssignment(assignmentId);
            return Ok();
        }

        [HttpGet("AssignmentSubmissions")]
        public async Task<ActionResult<List<Submission>>> getAssignmentSubmission(int assignmentId)
        {
            return Ok(await _assignmentService.GetAssignmentSubmissions(assignmentId));
        }
    }
}
