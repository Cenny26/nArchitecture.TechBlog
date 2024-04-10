using FluentValidation;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.FluentValidations.Categories
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Category Name");
        }
    }
}
