namespace Core.Entities;

public class Location
{
    public int LocationID { get; set; }
    
    public string? Title { get; set; }
    
    public string? Address { get; set; }
    
    public string? LocationType { get; set; }
    
    public string?  Geolocation { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public string? RegistrarUserName { get; set; }
}
