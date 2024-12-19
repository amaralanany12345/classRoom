using ClassRoom.Models;

namespace ClassRoom.Interfaces
{
    public interface ISubmission
    {
        Task<Submission> submitAssignment(int studentId,int assignmentId,FileUploadModel uploadedFile);
        Task<Submission> getStudentSubmitAssignment(int studentId,int assignmentId);
        Task deleteSubmissionOfAssignment(int studentId,int assignmentId);
    }
}
