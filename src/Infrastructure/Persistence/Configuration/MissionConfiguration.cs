using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AspireWebApp.Domain.Common.Interfaces;
using AspireWebApp.Domain.Teams;

namespace AspireWebApp.Infrastructure.Persistence.Configuration;

public class MissionConfiguration : AuditableConfiguration<Mission>
{
    public override void PostConfigure(EntityTypeBuilder<Mission> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Description)
            .HasMaxLength(Mission.DescriptionMaxLength)
            .IsRequired();
    }
}