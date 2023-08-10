using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Users")]
public class User
{
    [Key]
    public string? UserName { get; set; }
    
    public string? Password { get; set; }

    public bool IsActive { get; set; }
    
    public DateTime? SignUpDate { get; set; }
}
