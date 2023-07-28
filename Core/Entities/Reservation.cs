namespace Core.Entities;

public class Reservation
{
    public int ReservationID { get; set; }

    public DateTime RegistrationDate { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public decimal Cost { get; set; }
    
    public string? RegistrarUserName { get; set; }
    
    public int LocationID { get; set; }
}
