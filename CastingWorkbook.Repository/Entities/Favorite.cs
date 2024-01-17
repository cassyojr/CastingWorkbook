using System.ComponentModel.DataAnnotations;

namespace CastingWorkbook.Repository.Entities;

public class Favorite
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }

    public ICollection<User> Users { get; set; }

    [Required]
    public int ProjectId { get; set; }
    public Project Project { get; set; }

}
