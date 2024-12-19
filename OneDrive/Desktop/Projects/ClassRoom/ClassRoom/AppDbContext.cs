using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom
{
    public class AppDbContext:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> classRooms { get; set; }
        public DbSet<ClassRoomStudent> ClassRoomStudent { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<Submission> submissions { get; set; }
        public DbSet<AppFiles> appFiles { get; set; }
        public DbSet<StudentToken> studentTokens { get; set; }
        public DbSet<InstructorToken> instructorTokens { get; set; }
        public DbSet<Lecture> lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-NNDJ4G3D\SQLEXPRESS; Database =ClassRoom; Integrated Security =SSPI; TrustServerCertificate =True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
