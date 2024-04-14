using FluentValidation;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.FluentValidations.SocialMedias
{
    public class SocialMediaValidator : AbstractValidator<SocialMediaAccount>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.MediaName)
                .NotEmpty()
                .NotNull()
                .WithName("Social Media Name");
            RuleFor(x => x.NormalizedMediaName)
                .NotEmpty()
                .NotNull()
                .WithName("Normalized Social Media Name");
            RuleFor(x => x.MediaLink)
                .NotEmpty()
                .NotNull()
                .WithName("Social Media Link");
        }
    }
}
