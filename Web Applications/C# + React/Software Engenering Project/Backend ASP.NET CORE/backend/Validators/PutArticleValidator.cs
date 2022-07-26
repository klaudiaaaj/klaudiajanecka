using backend.Data;
using backend.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Validators
{
    public class PutArticleValidator : AbstractValidator<PutArticleDto>
    {
        private readonly backendContext _context;

        public PutArticleValidator(backendContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(1024)
                .WithMessage("Title cannot be shortest than 4 and longer than 1024 characters");

            RuleFor(x => x.CategoryId)
               .NotEmpty()
               .Must(CategoryExists)
                .Must(CategoryExists)
               .WithMessage("Category id is invalid. Check if category exists or is not null");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Wrong value for Status, is it out of range?");

        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
