using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface IClassRoom
    {
        Task<Class> createClassRoom(int instructorId,string title,string code);
        Task<Class> getClassRoom(int classRoomId);
        Task  deleteClassRoom(int classRoomId);
        Task<Class> joinToClassRoom(int classRoomId,int studentId,string code);
        Task<List<Student>> getClassRoomStudents(int classRoomId);
    }
}
