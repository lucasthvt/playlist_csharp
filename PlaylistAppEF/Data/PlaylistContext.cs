using Microsoft.EntityFrameworkCore;
using PlaylistAppEF.Models;

namespace PlaylistAppEF.Data;

public class PlaylistContext : DbContext
{
    public PlaylistContext()
    {
    }

    public PlaylistContext(DbContextOptions<PlaylistContext> options)
        : base(options)
    {
    }

    public DbSet<Chanson> Chansons => Set<Chanson>();
    public DbSet<Artiste> Artistes => Set<Artiste>();
    public DbSet<Playlist> Playlists => Set<Playlist>();
    public DbSet<PlaylistChanson> PlaylistChansons => Set<PlaylistChanson>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=playlist.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chanson>(entity =>
        {
            entity.HasIndex(chanson => chanson.Artiste)
                .HasDatabaseName("IX_Chansons_Artiste");
            entity.HasIndex(chanson => chanson.Genre)
                .HasDatabaseName("IX_Chansons_Genre");

            entity.HasOne(chanson => chanson.ArtisteRelation)
                .WithMany(artiste => artiste.Chansons)
                .HasForeignKey(chanson => chanson.ArtisteId)
                .OnDelete(DeleteBehavior.SetNull);

        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasIndex(playlist => playlist.Nom)
                .IsUnique()
                .HasDatabaseName("IX_Playlists_Nom");
        });

        modelBuilder.Entity<PlaylistChanson>(entity =>
        {
            entity.HasKey(link => new { link.PlaylistId, link.ChansonId });

            entity.HasOne(link => link.Chanson)
                .WithMany(chanson => chanson.PlaylistChansons)
                .HasForeignKey(link => link.ChansonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(link => link.Playlist)
                .WithMany(playlist => playlist.PlaylistChansons)
                .HasForeignKey(link => link.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        var seedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Artiste>().HasData(
            new Artiste { Id = 1, Nom = "Queen", Pays = "Royaume-Uni", CreeLe = seedDate },
            new Artiste { Id = 2, Nom = "Eagles", Pays = "États-Unis", CreeLe = seedDate },
            new Artiste { Id = 3, Nom = "The Weeknd", Pays = "Canada", CreeLe = seedDate },
            new Artiste { Id = 4, Nom = "Ed Sheeran", Pays = "Royaume-Uni", CreeLe = seedDate },
            new Artiste { Id = 5, Nom = "Eminem", Pays = "États-Unis", CreeLe = seedDate },
            new Artiste { Id = 6, Nom = "Drake", Pays = "Canada", CreeLe = seedDate },
            new Artiste { Id = 7, Nom = "Nirvana", Pays = "États-Unis", CreeLe = seedDate },
            new Artiste { Id = 8, Nom = "Adele", Pays = "Royaume-Uni", CreeLe = seedDate },
            new Artiste { Id = 9, Nom = "Michael Jackson", Pays = "États-Unis", CreeLe = seedDate },
            new Artiste { Id = 10, Nom = "Daft Punk", Pays = "France", CreeLe = seedDate },
            new Artiste { Id = 11, Nom = "Bee Gees", Pays = "Royaume-Uni", CreeLe = seedDate });

        modelBuilder.Entity<Chanson>().HasData(
            new Chanson { Id = 1, Titre = "Bohemian Rhapsody", Artiste = "Queen", ArtisteId = 1, Album = "A Night at the Opera", DureeSecondes = 354, Genre = "Rock", Annee = 1975, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 2, Titre = "Hotel California", Artiste = "Eagles", ArtisteId = 2, Album = "Hotel California", DureeSecondes = 391, Genre = "Rock", Annee = 1977, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 3, Titre = "Blinding Lights", Artiste = "The Weeknd", ArtisteId = 3, Album = "After Hours", DureeSecondes = 200, Genre = "Pop", Annee = 2019, Note = 4, AjouteLe = seedDate },
            new Chanson { Id = 4, Titre = "Shape of You", Artiste = "Ed Sheeran", ArtisteId = 4, Album = "÷ (Divide)", DureeSecondes = 234, Genre = "Pop", Annee = 2017, Note = 4, AjouteLe = seedDate },
            new Chanson { Id = 5, Titre = "Lose Yourself", Artiste = "Eminem", ArtisteId = 5, Album = "8 Mile Soundtrack", DureeSecondes = 326, Genre = "Rap", Annee = 2002, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 6, Titre = "God's Plan", Artiste = "Drake", ArtisteId = 6, Album = "Scorpion", DureeSecondes = 198, Genre = "Rap", Annee = 2018, Note = 4, AjouteLe = seedDate },
            new Chanson { Id = 7, Titre = "Smells Like Teen Spirit", Artiste = "Nirvana", ArtisteId = 7, Album = "Nevermind", DureeSecondes = 301, Genre = "Rock", Annee = 1991, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 8, Titre = "Rolling in the Deep", Artiste = "Adele", ArtisteId = 8, Album = "21", DureeSecondes = 228, Genre = "Soul", Annee = 2010, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 9, Titre = "Billie Jean", Artiste = "Michael Jackson", ArtisteId = 9, Album = "Thriller", DureeSecondes = 294, Genre = "Pop", Annee = 1982, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 10, Titre = "One More Time", Artiste = "Daft Punk", ArtisteId = 10, Album = "Discovery", DureeSecondes = 321, Genre = "Électro", Annee = 2000, Note = 5, AjouteLe = seedDate },
            new Chanson { Id = 11, Titre = "Get Lucky", Artiste = "Daft Punk", ArtisteId = 10, Album = "Random Access Memories", DureeSecondes = 369, Genre = "Électro", Annee = 2013, Note = 4, AjouteLe = seedDate },
            new Chanson { Id = 12, Titre = "Stayin' Alive", Artiste = "Bee Gees", ArtisteId = 11, Album = "Saturday Night Fever", DureeSecondes = 245, Genre = "Disco", Annee = 1977, Note = 4, AjouteLe = seedDate });

        modelBuilder.Entity<Playlist>().HasData(
            new Playlist { Id = 1, Nom = "Rock Classics", Description = "Les incontournables du rock", CreeLe = seedDate, ModifieLe = seedDate },
            new Playlist { Id = 2, Nom = "Pop Hits 2010-2020", Description = "Meilleures chansons pop", CreeLe = seedDate, ModifieLe = seedDate },
            new Playlist { Id = 3, Nom = "Électro Vibes", Description = "Pour danser toute la nuit", CreeLe = seedDate, ModifieLe = seedDate });

        modelBuilder.Entity<PlaylistChanson>().HasData(
            new PlaylistChanson { PlaylistId = 1, ChansonId = 1, Position = 1, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 1, ChansonId = 2, Position = 2, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 1, ChansonId = 7, Position = 3, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 2, ChansonId = 3, Position = 1, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 2, ChansonId = 4, Position = 2, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 2, ChansonId = 8, Position = 3, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 2, ChansonId = 9, Position = 4, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 3, ChansonId = 10, Position = 1, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 3, ChansonId = 11, Position = 2, AjouteLe = seedDate },
            new PlaylistChanson { PlaylistId = 3, ChansonId = 12, Position = 3, AjouteLe = seedDate });
    }
}
