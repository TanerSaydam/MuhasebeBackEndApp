using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Concrete
{
    public class EmailParameter
    {
        public int Id { get; set; }
        public string Smtp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public bool Html { get; set; }
    }

    public class EmailParameterConfiguration : IEntityTypeConfiguration<EmailParameter>
    {
        public void Configure(EntityTypeBuilder<EmailParameter> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Smtp).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Port).IsRequired();
            builder.Property(p => p.SSL).IsRequired();
            builder.Property(p => p.Html).IsRequired();
        }
    }
}
