using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Services
{
    public class SubmissionService : ISubmission
    {
        private readonly AppDbContext _context;
        private readonly StudentService _studentService;
        private readonly AssignmentService _assignmentService;
        private readonly FileService _fileService;

        public SubmissionService(AppDbContext context, StudentService studentService, AssignmentService assignmentService, FileService fileService)
        {
            _context = context;
            _studentService = studentService;
            _assignmentService = assignmentService;
            _fileService = fileService;
        }

        public async Task deleteSubmissionOfAssignment(int studentId, int assignmentId)
        {
            var submission=await getStudentSubmitAssignment(studentId, assignmentId);
            if (submission == null)
            {
                throw new ArgumentException("submission is not found");
            }

            await _fileService.deleteFile(submission.fileId);
            _context.submissions.Remove(submission);
            await _context.SaveChangesAsync();
        }

        public async Task<Submission> getStudentSubmitAssignment(int studentId, int assignmentId)
        {
            var submission = await _context.submissions.Where(a => a.studentId == studentId && a.assignmentId == assignmentId).FirstOrDefaultAsync();
            if (submission == null)
            {
                throw new ArgumentException("submission is not found");
            }
            return submission;
        }

        public async Task<Submission> submitAssignment(int studentId, int assignmentId, FileUploadModel uploadedFile)
        {
            var student=await _studentService.getStudent(studentId);
            var assignment=await _assignmentService.GetAssignment(assignmentId);
            var newSubmission=new Submission(studentId, assignmentId);

            var newFile = new AppFiles();
            var submittedFile= _fileService.UploadFile(uploadedFile);
            newFile.fileName=submittedFile.fileName;
            newFile.filePath=submittedFile.filePath;
            _context.appFiles.Add(newFile);
            await _context.SaveChangesAsync();

            newSubmission.student=student;
            newSubmission.assignment=assignment;
            newSubmission.fileId = newFile.id;
            _context.submissions.Add(newSubmission);
            await _context.SaveChangesAsync();
            return newSubmission;
        }
    }
}
