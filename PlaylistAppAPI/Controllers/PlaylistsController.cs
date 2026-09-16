using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistAppEF.Data;
using PlaylistAppEF.Models;

namespace PlaylistAppAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PlaylistsController(PlaylistContext ctx) : ControllerBase
{
    private readonly PlaylistContext _ctx = ctx;

    // GET /api/playlists
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PlaylistDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PlaylistDto>>> GetAll()
    {
        var playlists = await _ctx.Playlists
            .Include(playlist => playlist.PlaylistChansons)
                .ThenInclude(link => link.Chanson)
            .OrderBy(playlist => playlist.Nom)
            .ToListAsync();

        return Ok(playlists.Select(ToDto));
    }

    // GET /api/playlists/{id}
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PlaylistDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlaylistDto>> GetById(int id)
    {
        var playlist = await _ctx.Playlists
            .Include(item => item.PlaylistChansons.OrderBy(link => link.Position))
                .ThenInclude(link => link.Chanson)
            .FirstOrDefaultAsync(item => item.Id == id);

        return playlist is null
            ? NotFound(new { message = $"Playlist #{id} introuvable." })
            : Ok(ToDto(playlist));
    }

    // POST /api/playlists
    [HttpPost]
    [ProducesResponseType(typeof(PlaylistDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlaylistDto>> Create([FromBody] Playlist playlist)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        playlist.Id = 0;
        playlist.CreeLe = DateTime.UtcNow;
        playlist.ModifieLe = playlist.CreeLe;
        playlist.PlaylistChansons.Clear();

        _ctx.Playlists.Add(playlist);
        await _ctx.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, ToDto(playlist));
    }

    private static PlaylistDto ToDto(Playlist playlist)
        => new(
            playlist.Id,
            playlist.Nom,
            playlist.Description,
            playlist.CreeLe,
            playlist.ModifieLe,
            playlist.PlaylistChansons
                .OrderBy(link => link.Position)
                .Where(link => link.Chanson is not null)
                .Select(link => new ChansonDto(
                    link.Chanson!.Id,
                    link.Chanson.Titre,
                    link.Chanson.Artiste,
                    link.Chanson.Album,
                    link.Chanson.Genre,
                    link.Chanson.Label,
                    link.Chanson.DureeSecondes,
                    link.Chanson.Annee,
                    link.Chanson.Note,
                    link.Position))
                .ToList());
}

public sealed record PlaylistDto(
    int Id,
    string Nom,
    string Description,
    DateTime CreeLe,
    DateTime ModifieLe,
    IReadOnlyList<ChansonDto> Chansons);

public sealed record ChansonDto(
    int Id,
    string Titre,
    string Artiste,
    string Album,
    string Genre,
    string Label,
    int DureeSecondes,
    int Annee,
    int Note,
    int Position);