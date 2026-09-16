using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlaylistAppEF.Data;
using PlaylistAppEF.Models;
using Xunit;

namespace PlaylistAppAPI.Tests;

public class PlaylistsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public PlaylistsApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var aRetirer = services.Where(d =>
                    d.ServiceType == typeof(DbContextOptions<PlaylistContext>) ||
                    d.ServiceType == typeof(DbContextOptions) ||
                    d.ServiceType == typeof(PlaylistContext) ||
                    (d.ServiceType.FullName?.Contains("DbContextOptions") ?? false)
                ).ToList();
                foreach (var service in aRetirer) services.Remove(service);

                services.AddDbContext<PlaylistContext>(options =>
                    options.UseInMemoryDatabase("PlaylistsApiTestDB"));
            });
        });
        _client = _factory.CreateClient();

        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<PlaylistContext>();
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }

    [Fact(DisplayName = "GET /api/playlists → 200 OK")]
    public async Task GetAllPlaylists_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/playlists");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact(DisplayName = "GET /api/playlists/{id} → 404 si inexistant")]
    public async Task GetPlaylistById_Inexistante_Returns404()
    {
        var response = await _client.GetAsync("/api/playlists/9999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact(DisplayName = "POST /api/playlists → 201 Created")]
    public async Task PostPlaylist_Valide_Returns201()
    {
        var response = await _client.PostAsJsonAsync("/api/playlists", new
        {
            Nom = "Ma playlist API",
            Description = "Playlist de test"
        });

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
    }
}