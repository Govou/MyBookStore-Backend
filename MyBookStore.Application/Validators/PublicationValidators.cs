using FluentValidation;
using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.Validators
{
    internal class PublicationValidators : AbstractValidator<Publication>
    {
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
