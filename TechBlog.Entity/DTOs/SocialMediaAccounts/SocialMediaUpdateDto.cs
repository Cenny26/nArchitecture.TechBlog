namespace TechBlog.Entity.DTOs.SocialMediaAccounts
{
    public class SocialMediaUpdateDto
    {
        public Guid Id { get; set; }
        public string MediaName { get; set; }
        public string NormalizedMediaName { get; set; }
        public string MediaLink { get; set; }
    }
}
