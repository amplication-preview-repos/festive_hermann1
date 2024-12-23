namespace WebsiteScannerService.APIs.Dtos;

public class ScanRequest
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string Id { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Website { get; set; }
}
