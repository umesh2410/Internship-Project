namespace StudentApi.DTOs;

public class LoginResponse
{
    public required string Token { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
}
