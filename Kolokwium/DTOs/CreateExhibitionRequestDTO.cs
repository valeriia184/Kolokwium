namespace Kolokwium.DTOs;

public class CreateExhibitionRequestDTO
{
    public string Title { get; set; }
    public string Gallery { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ArtworkAssignmentDTO> Artworks { get; set; }
}

public class ArtworkAssignmentDTO
{
    public int ArtworkId { get; set; }
    public decimal InsuranceValue { get; set; }
}