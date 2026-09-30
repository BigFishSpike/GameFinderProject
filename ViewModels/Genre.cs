namespace GameFinder.ViewModels
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
        public string? Description { get; set; } //not sure if we'll keep it nullable, but that's for later


    }
}
