using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastingWorkbook.Repository.Configuration;

internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(x => x.Jobs).WithOne(x => x.Project);

        builder.HasData
        (
            new Project
            {
                Id = 1,
                Description = "McDonald's brand new Webpage",
                Owner = "Ronald McDonald",
                ProjectType = ProjectTypeEnum.FullTime,
                ProjectUnion = ProjectUnionEnum.PartOfTheUnion,
                CreatedDate = new DateTime(2023, 12, 1, 11, 11, 11),
                ExpirationDate = new DateTime(2024, 5, 15, 10, 10, 10)
            },
            new Project
            {
                Id = 2,
                Description = "Burger King's new delivery system",
                Owner = "James McLamore",
                ProjectType = ProjectTypeEnum.FullTime,
                ProjectUnion = ProjectUnionEnum.Both,
                CreatedDate = new DateTime(2024, 1, 1, 9, 10, 00),
                ExpirationDate = new DateTime(2024, 3, 22, 8, 30, 00)
            },
            new Project
            {
                Id = 3,
                Description = "KFC random customer service system",
                Owner = "Coronel Harland Sanders",
                ProjectType = ProjectTypeEnum.PartTime,
                ProjectUnion = ProjectUnionEnum.WithoutUnion,
                CreatedDate = new DateTime(2023, 10, 1, 8, 00, 00),
                ExpirationDate = new DateTime(2024, 3, 10, 7, 30, 00)
            },
            new Project
            {
                Id = 4,
                Description = "Skynet Classified Information",
                Owner = "Skynet",
                ProjectType = ProjectTypeEnum.FullTime,
                ProjectUnion = ProjectUnionEnum.WithoutUnion,
                CreatedDate = new DateTime(2024, 1, 1, 1, 1, 1),
                ExpirationDate = new DateTime(2034, 12, 12, 12, 12, 12)
            }
        );
    }
}
