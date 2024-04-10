using FluentValidation;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.FluentValidations.Users
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Name");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Surname");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(13)
                .WithName("Phone number");
        }
    }
}
