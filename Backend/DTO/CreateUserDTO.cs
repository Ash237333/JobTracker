using System.ComponentModel.DataAnnotations;

public record CreateUserDTO
(
    [Required] string UserName,
    [Required, EmailAddress] string UserEmail
);