using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<Instructor>> signUp(string userName, string email, string password)
        {
            return Ok(await _instructorService.signup(userName, email, password));
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<SigningResponse>> signIn(string email, string password)
        {
            return Ok(await _instructorService.signIn(email, password));
        }

        [HttpGet]
        public async Task<ActionResult<Instructor>> getInstructor(int id)
        {
            return Ok(await _instructorService.getInstructor(id));
        }

        [HttpDelete]
        public async Task<ActionResult<Instructor>> deleteInstructor(int id)
        {
            await _instructorService.deleteInstructor(id);
            return Ok();
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<StudentToken>> refreshToken(string refreshToken)
        {
            return Ok(await _instructorService.refreshToken(refreshToken));
        }

        [HttpDelete("deleteToken")]
        public async Task<ActionResult> deleteToken(int userId)
        {
            await _instructorService.deleteToken(userId);
            return Ok();
        }

    }
}
