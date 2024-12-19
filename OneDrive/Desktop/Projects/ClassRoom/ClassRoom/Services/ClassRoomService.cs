using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Services
{
    public class ClassRoomService : IClassRoom
    {
        private readonly AppDbContext _context;
        private readonly StudentService _studentService;
        private readonly InstructorService _instructorService;

        public ClassRoomService(AppDbContext context, StudentService studentService, InstructorService instructorService)
        {
            _context = context;
            _studentService = studentService;
            _instructorService = instructorService;
        }

        public async Task<Class> createClassRoom(int instructorId, string title, string code)
        {
            var instructor=await _instructorService.getInstructor(instructorId);
            var newClassRoom=new Class(instructorId, title, code);
            newClassRoom.instructor=instructor;
            _context.classRooms.Add(newClassRoom);
            await _context.SaveChangesAsync();
            return newClassRoom;
        }

        public async Task deleteClassRoom(int classRoomId)
        {
            var classRoom=await getClassRoom(classRoomId);
            _context.classRooms.Remove(classRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<Class> getClassRoom(int classRoomId)
        {
            var classRoom=await _context.classRooms.Where(a=>a.id == classRoomId).FirstOrDefaultAsync();
            if (classRoom == null)
            {
                throw new ArgumentNullException($"{classRoomId} does not exist");
            }
            return classRoom;
        }

        public async Task<List<Student>> getClassRoomStudents(int classRoomId)
        {
            var classRoom=await getClassRoom(classRoomId);
            var classRoomStudent=await _context.ClassRoomStudent.Where(a=>a.classRoomId==classRoomId).FirstOrDefaultAsync();
            if (classRoomStudent == null)
            {
                throw new ArgumentException("class room is not found");
            }
            var classRoomStudents=await _context.Students.Where(a=>a.id== classRoomStudent.studentId).ToListAsync();
            return classRoomStudents;
        }

        public async Task<Class> joinToClassRoom(int classRoomId, int studentId, string code)
        {
            var student=await _studentService.getStudent(studentId);
            var classRoom = await getClassRoom(classRoomId);
            if(code!= classRoom.code)
            {
                throw new ArgumentException("code is not correct");
            }
            var classRoomStudent = new ClassRoomStudent();
            classRoomStudent.studentId=studentId;
            classRoomStudent.student=student;
            classRoomStudent.classRoomId = classRoomId;
            classRoomStudent.classRoom=classRoom;
            _context.ClassRoomStudent.Add(classRoomStudent);
            await _context.SaveChangesAsync();
            classRoom.Students.Add(student);
            await _context.SaveChangesAsync();
            student.classRooms.Add(classRoom);
            await _context.SaveChangesAsync();
            return classRoom;
        }
    }
}
