namespace ClassRoom.Models
{
    public class Assignment
    {
        public int id { get;set; }
        public string title { get; set; }
        public string description { get; set; }
        public int score { get; set; }
        public Class classRoom { get; set; }
        public int classRoomId {  get; set; }   
        public List<Submission> submissions { get; set; }   =new List<Submission>();
        public Assignment(string title,string description, int score,int classRoomId)
        {
            this.title = title;
            this.description = description;
            this.score = score;
            this.classRoomId = classRoomId;
        }

    }
}
