using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("submissions").HasKey(a => new {a.studentId,a.assignmentId});
            builder.Property(a => a.studentScore).IsRequired();
            builder.HasOne(a=>a.assignment).WithMany(a=>a.submissions).HasForeignKey(a=>a.assignmentId);
            builder.HasOne(a=>a.student).WithMany(a=>a.studentSubmission).HasForeignKey(a=>a.studentId);    
            builder.HasOne(a => a.file).WithOne().HasForeignKey<Submission>(a => a.fileId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
