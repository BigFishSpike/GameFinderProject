namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFavouriteConfiguration : IEntityTypeConfiguration<UserFavourite>
    {
        public void Configure(EntityTypeBuilder<UserFavourite> entity)
        {
            entity.HasKey(uf => new 
            { 
                uf.UserId, uf.GameId 
            });

            entity.HasOne(uf => uf.User)
                .WithMany()
                .HasForeignKey(uf => uf.UserId);

            entity.HasOne(uf => uf.Game)
                .WithMany()
                .HasForeignKey(uf => uf.GameId);
        }
    }
}
