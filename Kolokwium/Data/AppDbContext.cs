using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<ArtworkExhibition> ArtworkExhibitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtworkExhibition>()
            .HasKey(ae => new { ae.ArtworkId, ae.ExhibitionId });

        modelBuilder.Entity<ArtworkExhibition>()
            .HasOne(ae => ae.Artwork)
            .WithMany(a => a.ArtworkExhibitions)
            .HasForeignKey(ae => ae.ArtworkId);

        modelBuilder.Entity<ArtworkExhibition>()
            .HasOne(ae => ae.Exhibition)
            .WithMany(e => e.ArtworkExhibitions)
            .HasForeignKey(ae => ae.ExhibitionId);
    }
}