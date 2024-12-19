using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment").HasKey(a=>a.id);
            builder.Property(a=>a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a=>a.title).IsRequired();
            builder.Property(a=>a.description).IsRequired();
            builder.Property(a=>a.score).IsRequired();
            builder.HasOne(a=>a.classRoom).WithMany(a=>a.assignments).HasForeignKey(a=>a.classRoomId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
