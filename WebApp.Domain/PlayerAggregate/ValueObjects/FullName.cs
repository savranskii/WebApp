using System.Text.Json.Serialization;

namespace WebApp.Domain.PlayerAggregate.ValueObjects;

public record FullName(
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName
);
