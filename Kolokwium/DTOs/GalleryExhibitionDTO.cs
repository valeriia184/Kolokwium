namespace Kolokwium.DTOs;

public class GalleryExhibitionDTO
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionDTO> Exhibitions { get; set; }
}

public class ExhibitionDTO
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDTO> Artworks { get; set; }
}

public class ArtworkDTO
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public ArtistDTO Artist { get; set; }
}

public class ArtistDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}