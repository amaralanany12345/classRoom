using ClassRoom.Migrations;
using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface ILecture
    {
        Task<Lecture> addLecture(string title, int classRoomId, FileUploadModel lectureFile);
        Task removeLecture(int lectureId);
        Task<List<Lecture>> GetClassRoomLectures(int classRoomId);
        Task<Lecture> GetLecture(int lectureId);
    }
}
