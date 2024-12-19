using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class ClassRoomConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("classRooms").HasKey(a=>a.id);
            builder.Property(a=>a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a=>a.Title).IsRequired();
            builder.Property(a=>a.code).IsRequired();
            builder.HasIndex(a=>a.code).IsUnique();
            builder.HasOne(a=>a.instructor).WithMany(a=>a.classRooms).HasForeignKey(a=>a.instructorId);
            builder.HasMany(a => a.Students).WithMany(a => a.classRooms).UsingEntity<ClassRoomStudent>();

        }
    }
}
