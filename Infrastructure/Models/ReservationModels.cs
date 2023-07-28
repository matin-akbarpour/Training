namespace Infrastructure.Models;

public class Reservations
{
    public int LocationID { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public decimal Cost { get; set; }
    
    public string? RegistrarUserName { get; set; }
}
