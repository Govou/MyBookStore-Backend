using FluentValidation;
using MyBookStore.Domain.Entities;
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

        protected public BookValidators(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            ValidateTitle();
            ValidateAuthor();
            ValidatePublisher();
            ValidatePublication();
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

        private void ValidatePublication()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.Publication)
                .Must(publication => _publicationValidator.Validate(publication).IsValid)
                .WithSeverity(Severity.Error)
                .WithMessage("Publication is invalid");
        }

        private void ValidateEdition()
        {
            RuleFor(publication => publication.Edition)
                .Must(edition => edition > 0)
                .WithSeverity(Severity.Error)
                .WithMessage("Edition must be higher than 0.");
        }

        private void ValidateYear()
        {
            RuleFor(publication => publication.Year)
                .Must(year => year <= DateTime.Today.Year)
                .WithSeverity(Severity.Error)
                .WithMessage("Year of publication can't be higher than current year.");
        }
    }
}
