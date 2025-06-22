using Kolokwium.Data;
using Kolokwium.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/galleries")]
public class GalleriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GalleriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetExhibitions(int id)
    {
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ArtworkExhibitions)
            .ThenInclude(ae => ae.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (gallery == null) return NotFound("Gallery not found");

        var result = new GalleryExhibitionDTO
        {
            GalleryId = gallery.Id,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate,
            Exhibitions = gallery.Exhibitions.Select(e => new ExhibitionDTO
            {
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                NumberOfArtworks = e.ArtworkExhibitions.Count,
                Artworks = e.ArtworkExhibitions.Select(ae => new ArtworkDTO
                {
                    Title = ae.Artwork.Title,
                    YearCreated = ae.Artwork.YearCreated,
                    InsuranceValue = ae.InsuranceValue,
                    Artist = new ArtistDTO
                    {
                        FirstName = ae.Artwork.Artist.FirstName,
                        LastName = ae.Artwork.Artist.LastName,
                        BirthDate = ae.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };

        return Ok(result);
    }
}