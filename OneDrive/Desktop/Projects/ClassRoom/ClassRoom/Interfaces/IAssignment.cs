using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface IAssignment
    {
        Task<Assignment> addAssignment(string title, string description, int score, int classRoomId);
        Task removeAssignment(int assignmentId);
        Task<Assignment> GetAssignment(int assignmentId);
        Task<List<Submission>> GetAssignmentSubmissions(int assignmentId);


    }
}
