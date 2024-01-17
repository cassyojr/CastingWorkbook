
using System.ComponentModel.DataAnnotations;

namespace CastingWorkbook.Repository.Entities;

public class Job
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
