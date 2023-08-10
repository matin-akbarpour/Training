using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Locations")]
public class Location
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocationId { get; set; }
    
    public string? Title { get; set; }
    
    public string? Address { get; set; }
    
    public string? LocationType { get; set; }
    
    public string?  Geolocation { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public string? RegistrarUserName { get; set; }
}
