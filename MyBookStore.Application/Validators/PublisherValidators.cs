using FluentValidation;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Domain.Validators
{
    public class PublisherValidators : AbstractValidator<Publisher>
    {
        IPublisherRepository _publisherRepository;
        protected PublisherValidators(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
            ValidateNameIsUnique();
            ValidateName();
        }

        private void ValidateNameIsUnique()
        {
            RuleFor(publisherBaseCommand => publisherBaseCommand.Name)
                .MustAsync(async (name, cancellationToken) => !(await _publisherRepository.ExistsAsync(name)))
                .WithSeverity(Severity.Error)
                .WithMessage("A publisher with this name already exists.");
        }

        private void ValidateName()
        {
            RuleFor(publisherBaseCommand => publisherBaseCommand.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }
    }
}
