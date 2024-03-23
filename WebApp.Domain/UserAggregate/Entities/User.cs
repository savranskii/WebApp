using WebApp.Domain.UserAggregate.ValueObjects;
using WebApp.Domain.Seeds;
using System.Text.Json.Serialization;

namespace WebApp.Domain.UserAggregate.Entities;

public class User : Entity
{
    [JsonInclude]
    [JsonPropertyName("id")]
    public override long Id { get; set; }

    [JsonInclude]
    [JsonPropertyName("email")]
    public string Email { get; private set; } = string.Empty;

    [JsonInclude]
    [JsonPropertyName("name")]
    public FullName Name { get; set; } = default!;

    [JsonInclude]
    [JsonPropertyName("address")]
    public Address Address { get; set; } = default!;

    [JsonInclude]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonInclude]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    public User()
    {
    }

    public User(string email, FullName name, Address address)
    {
        Email = email;
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetEmail(string email)
    {
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetName(FullName name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAddress(Address address)
    {
        Address = address;
        UpdatedAt = DateTime.UtcNow;
    }
}
