using System.ComponentModel.DataAnnotations;

namespace VideoGameCollectionTracker.Model
{
  public class VideoGameSystem
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
  }
}
