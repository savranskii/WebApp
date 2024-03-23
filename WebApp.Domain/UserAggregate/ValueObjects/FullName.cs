using System.Text.Json.Serialization;

namespace WebApp.Domain.UserAggregate.ValueObjects;

public record FullName(
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName
);
