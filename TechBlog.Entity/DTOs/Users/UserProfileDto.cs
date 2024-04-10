using Microsoft.AspNetCore.Http;
using TechBlog.Entity.Entities;

namespace TechBlog.Entity.DTOs.Users
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
