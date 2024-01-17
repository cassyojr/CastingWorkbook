using CastingWorkbook.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastingWorkbook.Repository.Configuration;

internal class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne(x => x.Project).WithMany(x => x.Jobs).HasForeignKey(x => x.ProjectId).IsRequired();

        builder.HasData
        (
            new Job
            {
                Id = 1,
                Description = "The employee will work developing dotnet features for the system",
                Title = ".Net Fullstack Developer",
                ProjectId = 1
            },
            new Job
            {
                Id = 2,
                Description = "Java backend developer needed ",
                Title = "Java Fullstack Developer",
                ProjectId = 2
            },
            new Job
            {
                Id = 3,
                Description = "Node engineer will create large scale structures for the company",
                Title = "Node Engineer",
                ProjectId = 2
            },
            new Job
            {
                Id = 4,
                Description = "Create awesome webpages will html, css, js",
                Title = "Ui/Ux Designer",
                ProjectId = 2
            },
            new Job
            {
                Id = 5,
                Description = "Will work fixing bugs on old webpages",
                Title = "Ui/Ux Junior Designer",
                ProjectId = 3
            },
            new Job
            {
                Id = 6,
                Description = "For some reason we need this developer and will work in some amazing old 2000 MVC bug fixes",
                Title = "Junior .Net MVC Developer",
                ProjectId = 3
            },
            new Job
            {
                Id = 7,
                Description = "We are searching for a AI engineer to help create the next Skynet so the machines can fulfill their destiny and rule the word",
                Title = "TOP Level AI MASTER Engineer",
                ProjectId = 3
            }
        );
    }
}
