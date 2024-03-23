namespace WebApp.Api.Application.Models;

public record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Street,
    string City,
    string Country,
    string ZipCode);
