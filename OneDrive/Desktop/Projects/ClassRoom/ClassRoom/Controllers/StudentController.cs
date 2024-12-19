using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ClassRoom.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<Student>> signUp(string userName, string email, string password)
        {
            return Ok(await _studentService.signup(userName, email, password));
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<SigningResponse>> signIn(string email, string password)
        {
            return Ok(await _studentService.signIn(email, password));
        }

        [HttpGet]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<Student>> getStudent(int studentId)
        {
            return Ok(await _studentService.getStudent(studentId));
        }


        [HttpDelete]
        public async Task<ActionResult> deleteStudent(int studentId)
        {
            await _studentService.deleteStudent(studentId);
            return Ok();
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<StudentToken>> refreshToken(string refreshToken)
        {
            return Ok(await _studentService.refreshToken(refreshToken));
        }

        [HttpDelete("deleteToken")]
        public async Task<ActionResult> deleteToken(int userId)
        {
            await _studentService.deleteToken(userId);
            return Ok();
        }

    }
}
