using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Services
{
    public class AssignmentService : IAssignment
    {
        private readonly AppDbContext _context;
        private readonly ClassRoomService _classRoomService;

        public AssignmentService(AppDbContext context,  ClassRoomService classRoomService)
        {
            _context = context;
            _classRoomService = classRoomService;
        }

        public async Task<Assignment> addAssignment(string title, string description, int score, int classRoomId)
        {
            var classRoom = await _classRoomService.getClassRoom(classRoomId); 
            var newAssignment=new Assignment(title, description, score, classRoomId);
            newAssignment.classRoom = classRoom;
            _context.assignments.Add(newAssignment);    
            await _context.SaveChangesAsync();
            return newAssignment;
        }

        public async Task<Assignment> GetAssignment(int assignmentId)
        {
            var assignment=await _context.assignments.Where(a=>a.id==assignmentId).FirstOrDefaultAsync();
            if(assignment==null)
            {
                throw new ArgumentException("assignment is not found");
            }
            return assignment;

        }

        public async Task<List<Submission>> GetAssignmentSubmissions(int assignmentId)
        {
            var assignment=await GetAssignment(assignmentId);
            var assignmentSubmission=await _context.submissions.Where(a=>a.assignmentId==assignmentId).ToListAsync();
            return assignmentSubmission;
        }

        public async Task removeAssignment(int assignmentId)
        {
            var assignment=await GetAssignment(assignmentId);
            _context.assignments.Remove(assignment);
            await _context.SaveChangesAsync();
        }
    }
}
