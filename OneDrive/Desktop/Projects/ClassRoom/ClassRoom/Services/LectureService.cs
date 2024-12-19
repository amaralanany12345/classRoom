using ClassRoom.Interfaces;
using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Services
{
    public class LectureService : ILecture
    {
        private readonly AppDbContext _context;
        private readonly ClassRoomService _classRoomService;
        private readonly FileService _fileService;

        public LectureService(AppDbContext context, ClassRoomService classRoomService, FileService fileService)
        {
            _context = context;
            _classRoomService = classRoomService;
            _fileService = fileService;
        }

        public async Task<Lecture> addLecture(string title, int classRoomId, FileUploadModel lectureFile)
        {
            var classRoom=await _classRoomService.getClassRoom(classRoomId);
            var newLecture=new Lecture(title, classRoomId);


            var uploadedLectureFile = _fileService.UploadFile(lectureFile);
            _context.appFiles.Add(uploadedLectureFile);
            await _context.SaveChangesAsync();

            newLecture.lectureFile=uploadedLectureFile;
            newLecture.lectureFileId=uploadedLectureFile.id;
            _context.lectures.Add(newLecture);
            await _context.SaveChangesAsync();
            return newLecture;
        }

        public async Task<List<Lecture>> GetClassRoomLectures(int classRoomId)
        {
            var classRoom=await _classRoomService.getClassRoom(classRoomId);
            var classRoomLectures=await _context.lectures.Where(a=>a.classRoomId==classRoomId).ToListAsync();
            return classRoomLectures;
        }

        public async Task<Lecture> GetLecture(int lectureId)
        {
            var lecture=await _context.lectures.Where(a=>a.id==lectureId).FirstOrDefaultAsync();
            if (lecture == null)
            {
                throw new ArgumentException("lecture is not found");
            }
            return lecture;
        }

        public async Task removeLecture(int lectureId)
        {
            var lecture=await GetLecture(lectureId);
            await _fileService.deleteFile(lecture.lectureFileId);

            _context.lectures.Remove(lecture);
            await _context.SaveChangesAsync();
        }
    }
}
