namespace GameFinder.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GenreDescriptionMaxLength)]
        public string? Description { get; set; }


        [MaxLength(GenreImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        = new HashSet<Game>();
    }
}
