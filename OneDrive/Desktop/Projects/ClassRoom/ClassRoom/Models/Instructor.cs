namespace ClassRoom.Models
{
    public class Instructor:User
    {
        public List<Class> classRooms{ get; set; }= new List<Class>();
        public List<InstructorToken> tokens { get; set; }=new List<InstructorToken>();
        public Instructor(string userName, string email, string password)
        {
            this.userName = userName;
            this.email = email;
            this.password = password;
            role = Enums.UserRole.instructor;
        }
    }
}
