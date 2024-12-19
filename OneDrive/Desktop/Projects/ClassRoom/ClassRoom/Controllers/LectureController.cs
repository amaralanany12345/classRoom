using ClassRoom.Models;
using ClassRoom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly LectureService _lectureService;

        public LectureController(LectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpPost]
        public async Task<ActionResult<Lecture>> uploadLecture(string title, int classRoomId, [FromForm] FileUploadModel uploadedLecture)
        {
            return Ok(await _lectureService.addLecture(title,classRoomId, uploadedLecture));
        }

        [HttpGet]
        public async Task<ActionResult<Lecture>> getLecture(int lectureId)
        {
            return Ok(await _lectureService.GetLecture(lectureId));
        }

        [HttpGet("classRoomLectures")]
        public async Task<ActionResult<List<Lecture>>> getClassRoomLectures(int classRoomId)
        {
            return Ok(await _lectureService.GetClassRoomLectures(classRoomId));
        }

        [HttpDelete]
        public async Task<ActionResult> deleteLecture(int lectureId)
        {
            await _lectureService.removeLecture(lectureId);
            return Ok();
        }
    }
}
