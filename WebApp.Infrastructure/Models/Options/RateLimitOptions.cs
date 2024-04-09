using System.ComponentModel.DataAnnotations;

namespace WebApp.Infrastructure.Models.Options;

public class RateLimitOptions
{
    [Required]
    public int PermitLimit { get; set; } = 100;
    [Required]
    public int Window { get; set; } = 10;
    [Required]
    public int QueueLimit { get; set; } = 2;
}
