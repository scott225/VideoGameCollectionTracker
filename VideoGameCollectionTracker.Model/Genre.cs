using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoGameCollectionTracker.Model
{
  public class Genre
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<VideoGame> VideoGames { get; set; }
  }
}
