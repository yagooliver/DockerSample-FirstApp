using DockerSample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DockerSample.Infra.Data.Mapping
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
