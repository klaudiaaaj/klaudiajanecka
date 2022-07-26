using backend.Data;
using backend.Models;
using FluentValidation;
using System.Linq;

namespace backend.Validators
{
    public class ArticleValidator : AbstractValidator<PostArticleDto>
    {
        private readonly backendContext _context;

        public ArticleValidator(backendContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(1024)
                .WithMessage("Title cannot be shortest than 4 and longer than 1024 characters");

            RuleFor(x => x.Title)
               .Must(IsTitleUnique)
               .WithMessage("Title already exists");

            RuleFor(x => x.CategoryId)
               .NotEmpty()
               .Must(CategoryExists)
                .Must(CategoryExists)
               .WithMessage("Category id is invalid. Check if category exists or is not null");

        }

        public bool IsTitleUnique(string title)
        {
            if (title != null)
                return !_context.Articles.Any(x =>
                  x.Title.Equals(title));
            else return false;
        }
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}


