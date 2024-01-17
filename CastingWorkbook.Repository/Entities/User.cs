using System.ComponentModel.DataAnnotations;

namespace CastingWorkbook.Repository.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }

    public ICollection<Favorite> Favorites { get; set; }
}
