namespace WebsiteScannerService.APIs.Dtos;

public class ScanRequestUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Website { get; set; }
}
