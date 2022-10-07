using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManager.Domain.Common.Entities;

namespace PatientManager.Sql.Mappings
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsOne(patient => patient.Person,
                navigationBuilder =>
                {
                    navigationBuilder.Property(person => person.Name)
                                     .HasColumnName("Name");
                    navigationBuilder.Property(person => person.Photo)
                                     .HasColumnName("Photo");
                    navigationBuilder.Property(person => person.CPF)
                                     .HasColumnName("CPF");
                    navigationBuilder.Property(person => person.RG)
                                     .HasColumnName("RG");
                });
        }
    }
}
