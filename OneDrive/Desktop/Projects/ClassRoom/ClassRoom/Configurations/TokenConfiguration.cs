using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoom.Configurations
{
    public class TokenConfiguration<T> : IEntityTypeConfiguration<Token<T>> where T:class 
    {
        public void Configure(EntityTypeBuilder<Token<T>> builder)
        {
            builder.ToTable("tokens").HasKey(a=>a.id);
            builder.Property(a=>a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(a=>a.token).IsRequired();
            builder.Property(a=>a.created).IsRequired();
            builder.Property(a=>a.expires).IsRequired();
            builder.Property(a=>a.revoked);
            builder.HasOne(a=>a.user).WithMany().HasForeignKey(a=>a.userId);

        }
    }
}
