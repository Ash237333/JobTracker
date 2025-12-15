using System.ComponentModel.DataAnnotations;

public record UpdateUserDTO
(
    string? UserName,
    [EmailAddress] string? UserEmail
);