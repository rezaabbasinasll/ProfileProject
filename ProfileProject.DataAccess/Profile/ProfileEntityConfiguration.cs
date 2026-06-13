using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileProject.DataAccess.Persistence.Configuration;
using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.DataAccess.Profile;

public class ProfileEntityConfiguration : BaseModelBuilderConfiguration<ProfileEntity>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<ProfileEntity> builder)
    {
        builder.Property(p => p.FullName)
                 .HasMaxLength(200)
                 .IsRequired();

        builder.Property(p => p.Email)
                .HasMaxLength(300)
                .IsRequired();

        builder.Property(p => p.Bio)
            .IsRequired(false);

        builder.HasIndex(p => p.Email)
                .IsUnique();


        builder.OwnsMany(s => s.Skills, skill =>
        {
            skill.ToTable("ProfileSkils");

            skill.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired(true);            

            skill.Property(x => x.SkillLevel)
                    .HasConversion<int>()
                    .IsRequired(true);

            skill.WithOwner().HasForeignKey("ProfileId");

            skill.HasIndex(x => x.Name).IsUnique();
        });

    }
}
