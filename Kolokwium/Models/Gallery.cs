namespace Kolokwium.Models;

public class Gallery
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }

    public ICollection<Exhibition> Exhibitions { get; set; }
}