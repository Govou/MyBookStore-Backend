using FluentValidation;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Domain.Validators
{
    public class AuthorValidators : AbstractValidator<Author>
    {
        private readonly IAuthorRepository _authorRepository;

        protected AuthorValidators(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            ValidateNameIsUnique();
            ValidateName();
        }

        private void ValidateNameIsUnique()
        {
            RuleFor(authorBaseCommand => authorBaseCommand.Name)
                .MustAsync(async (name, cancellationToken) => !(await _authorRepository.ExistsAsync(name)))
                .WithSeverity(Severity.Error)
                .WithMessage("A author with this name already exists.");
        }

        private void ValidateName()
        {
            RuleFor(authorBaseCommand => authorBaseCommand.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }
    }
}
