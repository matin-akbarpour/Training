namespace Core.Entities;

public class User
{
    public string? UserName { get; set; }
    
    public string? Password { get; set; }

    public bool IsActive { get; set; }
    
    public DateTime? SignUpDate { get; set; }
}
