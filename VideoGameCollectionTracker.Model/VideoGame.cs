using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoGameCollectionTracker.Model
{
  public class VideoGame
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<VideoGameSystem> Systems { get; set; }

    public ICollection<Genre> Genres { get; set; }
  }
}
