namespace Kolokwium.Models;

public class Artwork
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int YearCreated { get; set; }

    public int ArtistId { get; set; }
    public Artist Artist { get; set; }

    public ICollection<ArtworkExhibition> ArtworkExhibitions { get; set; }
}