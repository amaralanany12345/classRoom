﻿using ClassRoom.Enums;

namespace ClassRoom.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get;set; }
        public string email { get; set; }   
        public string password { get; set; }
        public UserRole role { get; set; }
    }
}
