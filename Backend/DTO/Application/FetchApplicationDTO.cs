public record FetchApplicationDTO(
    int UserId,
    int CompanyId,
    string JobTitle,
    string? JobDescription,
    string Status,
    int? Salary
    );