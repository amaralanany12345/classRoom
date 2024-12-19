namespace ClassRoom.Models
{
    public class Student:User
    {
        public List<Class> classRooms { get; set; }=new List<Class>();
        public List<ClassRoomStudent> ClassRoomStudents { get; set; }= new List<ClassRoomStudent>();
        public List<Submission> studentSubmission { get; set; }= new List<Submission>();
        public List<StudentToken> tokens { get; set; }=new List<StudentToken>();
        public Student(string userName,string email,string password)
        {
            this.userName = userName;
            this.email = email;
            this.password = password;
            role = Enums.UserRole.student;
        }
    }
}
