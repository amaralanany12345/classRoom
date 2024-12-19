namespace ClassRoom.Models
{
    public class Submission
    {
        //public int id { get;set; }
        public int studentId { get;set; }
        public Student student { get;set; }
        public int assignmentId { get;set; }
        public Assignment assignment { get;set; }
        public int studentScore { get;set; }
        public AppFiles file { get;set; }
        public int fileId { get;set; }
        public Submission(int studentId, int assignmentId)
        {
            this.studentId = studentId;
            this.assignmentId = assignmentId;
            this.fileId = fileId;
        }   
    }
}
