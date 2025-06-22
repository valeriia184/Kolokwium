namespace Kolokwium.Models;

public class Exhibition
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int GalleryId { get; set; }
    public Gallery Gallery { get; set; }

    public ICollection<ArtworkExhibition> ArtworkExhibitions { get; set; }
}