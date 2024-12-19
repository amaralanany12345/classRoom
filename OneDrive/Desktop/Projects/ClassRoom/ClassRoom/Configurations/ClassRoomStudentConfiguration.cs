using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class ClassRoomStudentConfiguration : IEntityTypeConfiguration<ClassRoomStudent>
    {
        public void Configure(EntityTypeBuilder<ClassRoomStudent> builder)
        {
            builder.ToTable("classRoomStudents").HasKey(a => new { a.studentId, a.classRoomId });
            builder.HasOne(a=>a.classRoom).WithMany(a=>a.ClassRoomStudents).HasForeignKey(a=>a.classRoomId);
            builder.HasOne(a=>a.student).WithMany(a=>a.ClassRoomStudents).HasForeignKey(a=>a.studentId);
        }
    }
}
