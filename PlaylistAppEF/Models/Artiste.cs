using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaylistAppEF.Models;

[Table("Artistes")]
public class Artiste
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nom { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Pays { get; set; } = string.Empty;

    public DateTime CreeLe { get; set; } = DateTime.UtcNow;

    public ICollection<Chanson> Chansons { get; set; } = new List<Chanson>();
}
