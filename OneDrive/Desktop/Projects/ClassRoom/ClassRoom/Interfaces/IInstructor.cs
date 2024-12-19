using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface IInstructor
    {
        Task<Instructor> getInstructor(int id);
        Task deleteInstructor(int id);
    }
}
