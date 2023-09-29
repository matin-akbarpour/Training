namespace IntegrationTest.Models;

public class PatchDoc
{
    public string? op { get; set; }
    public string? path { get; set; }
    public string? value { get; set; }
}
