using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students").HasKey(a => a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.userName).IsRequired();
            builder.Property(a => a.email).IsRequired();
            builder.Property(a => a.password).IsRequired();
            builder.HasMany(a=>a.classRooms).WithMany(a=>a.Students).UsingEntity<ClassRoomStudent>();
        }
    }
}
