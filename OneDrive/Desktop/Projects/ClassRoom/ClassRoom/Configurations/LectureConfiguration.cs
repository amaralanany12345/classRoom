using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("lectures").HasKey(a=>a.id);
            builder.Property(a=>a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a=>a.title).IsRequired();
            builder.HasOne(a=>a.classRoom).WithMany(a=>a.lectures).HasForeignKey(a=>a.classRoomId);
            builder.HasOne(a=>a.lectureFile).WithMany().HasForeignKey(a=>a.lectureFileId);
        }
    }
}
