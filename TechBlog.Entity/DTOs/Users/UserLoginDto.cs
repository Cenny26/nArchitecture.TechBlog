namespace TechBlog.Entity.DTOs.Users;

public class UserLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}