using CastingWorkbook.Repository.Enums;
using System.ComponentModel.DataAnnotations;

namespace CastingWorkbook.Repository.Entities;

public class Project
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    public string Owner { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public ProjectTypeEnum ProjectType { get; set; }
    [Required]
    public ProjectUnionEnum ProjectUnion { get; set; }

    public ICollection<Job> Jobs { get; set; }
}
