using FluentValidation;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.FluentValidations.Articles
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Title");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(1500)
                .WithName("Content");
        }
    }
}
