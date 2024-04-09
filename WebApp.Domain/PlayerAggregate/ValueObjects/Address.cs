using System.Text.Json.Serialization;

namespace WebApp.Domain.PlayerAggregate.ValueObjects;

public record Address(
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("zipCode")] string ZipCode
);
