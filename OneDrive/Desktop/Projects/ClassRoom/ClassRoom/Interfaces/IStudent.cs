using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface IStudent
    {
        Task<Student> getStudent(int id);
        Task deleteStudent(int id);
    } 
}
