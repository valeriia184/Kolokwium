namespace Kolokwium.Models;

public class ArtworkExhibition
{
    public int ArtworkId { get; set; }
    public Artwork Artwork { get; set; }

    public int ExhibitionId { get; set; }
    public Exhibition Exhibition { get; set; }

    public decimal InsuranceValue { get; set; }
}