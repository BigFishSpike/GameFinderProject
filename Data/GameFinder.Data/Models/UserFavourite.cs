namespace GameFinder.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFavourite
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; } = null!;

    }
}
