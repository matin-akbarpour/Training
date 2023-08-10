using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Reservations")]
public class Reservation
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReservationId { get; set; }

    public DateTime RegistrationDate { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public decimal Cost { get; set; }
    
    public string? RegistrarUserName { get; set; }
    
    public int LocationId { get; set; }
}
