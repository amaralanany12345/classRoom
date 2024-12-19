namespace ClassRoom.Models
{
    public class Lecture
    {
        public int id { get; set; } 
        public string title { get; set; }
        public int classRoomId { get; set; }
        public Class classRoom { get; set; }
        public int lectureFileId { get; set; }
        public AppFiles? lectureFile { get; set; }
        public Lecture( string title, int classRoomId)
        {
            this.title = title;
            this.classRoomId = classRoomId;
        }
    }
}
