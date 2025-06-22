using Kolokwium.Data;
using Kolokwium.DTOs;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/exhibitions")]
public class ExhibitionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExhibitionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateExhibition([FromBody] CreateExhibitionRequestDTO request)
    {
        var gallery = await _context.Galleries.FirstOrDefaultAsync(g => g.Name == request.Gallery);
        if (gallery == null) return NotFound("Gallery not found");

        var artworks = await _context.Artworks
            .Include(a => a.Artist)
            .Where(a => request.Artworks.Select(x => x.ArtworkId).Contains(a.Id))
            .ToListAsync();

        if (artworks.Count != request.Artworks.Count)
            return NotFound("Some artworks were not found");

        var artworkExhibitions = request.Artworks.Select(a =>
        {
            var art = artworks.First(x => x.Id == a.ArtworkId);
            return new ArtworkExhibition
            {
                Artwork = art,
                InsuranceValue = a.InsuranceValue
            };
        }).ToList();

        var exhibition = new Exhibition
        {
            Title = request.Title,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Gallery = gallery,
            ArtworkExhibitions = artworkExhibitions
        };

        await _context.Exhibitions.AddAsync(exhibition);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateExhibition), new { id = exhibition.Id }, null);
    }
}