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
    public class BookValidators : AbstractValidator<Book>
    {
        private readonly IBookRepository _bookRepository;

        protected BookValidators(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            ValidateTitle();
            ValidateAuthor();
            ValidatePublisher();
        }

        protected void ValidateNameIsUniqueOnCreate()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.Title)
                .MustAsync(async (title, cancellationToken) => !(await _bookRepository.ExistsAsync(title)))
                .WithSeverity(Severity.Error)
                .WithMessage("A book with this name already exists.");
        }

        private void ValidateTitle()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.Title)
                .Must(title => !string.IsNullOrWhiteSpace(title))
                .WithSeverity(Severity.Error)
                .WithMessage("Title can't be empty");
        }

        private void ValidateAuthor()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.AuthorId)
                .Must(authorId => !Guid.Empty.Equals(authorId))
                .WithSeverity(Severity.Error)
                .WithMessage("Author can't be empty");
        }

        private void ValidatePublisher()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.PublisherId)
                .Must(publisherId => !Guid.Empty.Equals(publisherId))
                .WithSeverity(Severity.Error)
                .WithMessage("Publisher can't be empty");
        }

       
    }
}
