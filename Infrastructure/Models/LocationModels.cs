using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models;

public class Locations
{
    public string? Title { get; set; }
    
    public string? Address { get; set; }
    
    public string? LocationType { get; set; }
    
    public string? Geolocation { get; set; }
    
    public string? RegistrarUserName { get; set; }
}

[Table("Locations")]
public class UpdateDeleteLocations
{
    [Key] [Required]
    public int LocationID { get; set; }

    [Required]
    public string? Title { get; set; }
    
    [Required]
    public string? Address { get; set; }
    
    [Required]
    public string? LocationType { get; set; }
    
    [Required]
    public string? Geolocation { get; set; }
}
