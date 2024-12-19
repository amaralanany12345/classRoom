namespace ClassRoom.Models
{
    public class Token<T> where T : class
    {
        public int id { get;set; }
        public int userId { get;set; }
        public T user { get;set; }   
        public string token { get; set; }
        public DateTime expires { get;set; }
        public bool isExpired => DateTime.Now > expires;
        public DateTime created { get;set; }
        public DateTime? revoked { get;set; }
        public bool isActive=>  revoked==null && !isExpired;
    }
}
