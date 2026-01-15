using System.ComponentModel.DataAnnotations;

namespace VideoGameCatalogue.Api.Models
{
    public class VideoGame
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Platform { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
