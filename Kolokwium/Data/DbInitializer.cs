using Kolokwium.Models;

namespace Kolokwium.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Galleries.Any()) return;

        var picasso = new Artist
        {
            FirstName = "Pablo",
            LastName = "Picasso",
            BirthDate = new DateTime(1881, 10, 25)
        };

        var kahlo = new Artist
        {
            FirstName = "Frida",
            LastName = "Kahlo",
            BirthDate = new DateTime(1907, 7, 6)
        };

        context.Artists.AddRange(picasso, kahlo);
        context.SaveChanges();

        var guernica = new Artwork
        {
            Title = "Guernica",
            YearCreated = 1937,
            Artist = picasso
        };

        var fridas = new Artwork
        {
            Title = "The Two Fridas",
            YearCreated = 1939,
            Artist = kahlo
        };

        context.Artworks.AddRange(guernica, fridas);
        context.SaveChanges();

        var gallery = new Gallery
        {
            Name = "Modern Art Space",
            EstablishedDate = new DateTime(2001, 9, 12)
        };

        context.Galleries.Add(gallery);
        context.SaveChanges();

        var exhibition = new Exhibition
        {
            Title = "20th Century Giants",
            StartDate = new DateTime(2024, 5, 1),
            EndDate = new DateTime(2024, 9, 1),
            Gallery = gallery
        };

        context.Exhibitions.Add(exhibition);
        context.SaveChanges();

        var ae1 = new ArtworkExhibition
        {
            Artwork = guernica,
            Exhibition = exhibition,
            InsuranceValue = 1_000_000M
        };

        var ae2 = new ArtworkExhibition
        {
            Artwork = fridas,
            Exhibition = exhibition,
            InsuranceValue = 800_000M
        };

        context.ArtworkExhibitions.AddRange(ae1, ae2);
        context.SaveChanges();
    }
}
