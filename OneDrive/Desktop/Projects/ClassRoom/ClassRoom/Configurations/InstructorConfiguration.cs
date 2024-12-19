using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors").HasKey(a=>a.id);
            builder.Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a => a.userName).IsRequired();
            builder.Property(a => a.email).IsRequired();
            builder.Property(a => a.password).IsRequired();
        }
    }
}
