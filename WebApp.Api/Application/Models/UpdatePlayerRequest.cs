﻿namespace WebApp.Api.Application.Models;

public record UpdatePlayerRequest(
    long Id,
    string FirstName,
    string LastName,
    string Street,
    string City,
    string Country,
    string ZipCode);
