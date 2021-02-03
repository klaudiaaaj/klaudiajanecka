using backend.Data;
using backend.Models;
using FluentValidation;
using System.Linq;

namespace backend.Validators
{
    public class CategoryValidator : AbstractValidator<PtCategoryDto>
    {
        private readonly backendContext _context;

        public CategoryValidator(backendContext context)
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

        }

        public bool IsTitleUnique(string title)
        {
            if (title != null)
                return !_context.Categories.Any(x =>
                  x.Title.Equals(title));
            else return false;
        }
      
    }
}

