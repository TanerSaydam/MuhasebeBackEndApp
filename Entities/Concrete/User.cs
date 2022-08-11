using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string ConfirmValue { get; set; }
        public bool IsConfirm { get; set; }
        public string ForgotPasswordValue { get; set; }
        public DateTime? ForgotPasswordRequestDate { get; set; }
        public bool IsForgotPasswordComplete { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.ConfirmValue).IsRequired();
            builder.Property(p => p.IsConfirm).IsRequired();            
        }
    }
}
