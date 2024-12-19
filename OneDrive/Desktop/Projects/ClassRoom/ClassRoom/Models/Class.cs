namespace ClassRoom.Models
{
    public class Class
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string code { get; set; }
        public int instructorId { get; set; }
        public Instructor instructor { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<ClassRoomStudent> ClassRoomStudents { get; set; }= new List<ClassRoomStudent>();
        public List<Assignment> assignments { get; set; }= new List<Assignment>();
        public List<Lecture> lectures { get; set; }= new List<Lecture>();
        public Class(int instructorId,string title,string code)
        {
            this.instructorId = instructorId;
            this.Title = title;
            this.code = code;
        }
    }
}
