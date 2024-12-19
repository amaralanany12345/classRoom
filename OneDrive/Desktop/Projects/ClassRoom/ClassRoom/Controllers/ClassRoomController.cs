using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClassRoomController : ControllerBase
    {
        private readonly ClassRoomService _classRoomService;

        public ClassRoomController(ClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        [HttpPost]
        public async Task<ActionResult<Class>> createClassRoom(int instructorId, string title, string code)
        {
            return Ok(await _classRoomService.createClassRoom(instructorId, title, code));
        }
        [HttpGet]
        public async Task<ActionResult<Class>> getClassRoom(int classRoomId)
        {
            return Ok(await _classRoomService.getClassRoom(classRoomId));
        }

        [HttpGet("classRoomStudents")]
        public async Task<ActionResult<Class>> getClassRoomStudents(int classRoomId)
        {
            return Ok(await _classRoomService.getClassRoomStudents(classRoomId));
        }
        [HttpPut("join to class room")]
        public async Task<ActionResult<Class>> joinToClassRoomStudents(int classRoomId, int studentId, string code)
        {
            return Ok(await _classRoomService.joinToClassRoom(classRoomId, studentId, code));
        }
        [HttpDelete]
        public async Task<ActionResult> deleteClassRoom(int classRoomId)
        {
            await _classRoomService.deleteClassRoom(classRoomId);
            return Ok();
        }
    }
}
