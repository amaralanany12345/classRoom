namespace ClassRoom.Models
{
    public class ClassRoomStudent
    {
        public int studentId { get;set; }
        public Student student { get;set; }
        public int classRoomId { get;set; }
        public Class classRoom { get;set; } 
        
    }
}
