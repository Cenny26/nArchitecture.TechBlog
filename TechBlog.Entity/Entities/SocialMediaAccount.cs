using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities
{
    public class SocialMediaAccount : EntityBase
    {
        public SocialMediaAccount() { }
        public SocialMediaAccount(string mediaName, string normalizedMediaName, string mediaLink, string createdBy)
        {
            MediaName = mediaName;
            NormalizedMediaName = normalizedMediaName;
            MediaLink = mediaLink;
            CreatedBy = createdBy;
        }

        public string MediaName { get; set; }
        public string NormalizedMediaName { get; set; }
        public string MediaLink { get; set; }
    }
}
