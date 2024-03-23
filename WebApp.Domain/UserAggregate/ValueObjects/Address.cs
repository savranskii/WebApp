using System.Text.Json.Serialization;

namespace WebApp.Domain.UserAggregate.ValueObjects;

public record Address(
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("zipCode")] string ZipCode
);
