using FluentValidation;
using FluentValidation.Results;
using System;
using Week14.Model;

namespace Week14
{
    public class PersonValidator : AbstractValidator<Respondent>
    {
        public PersonValidator()
        {
            RuleFor(person => person.CreateDate)
                 .Must(BeAValidDate)
                 .WithMessage("The create date must not be greater than today.");

            RuleFor(person => person.Firstname)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("The first name must be between 1 and 50 characters long.");

            RuleFor(person => person.Lastname)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("The last name must be between 1 and 50 characters long.");

            RuleFor(person => person.JobPosition)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("The job position must be between 1 and 50 characters long.");

            RuleFor(person => person.Salary)
                .InclusiveBetween(0, 10000)
                .WithMessage("The salary must be between 0 and 10,000.");

            RuleFor(person => person.WorkExperience)
                .NotEmpty()
                .WithMessage("The work experience must not be empty.");

            RuleFor(person => person.PersonAddress.Country)
                .NotEmpty()
                .WithMessage("The country must not be empty.");

            RuleFor(person => person.PersonAddress.City)
                .NotEmpty()
                .WithMessage("The city must not be empty.");

            RuleFor(person => person.PersonAddress.HomeNumber)
                .NotEmpty()
                .WithMessage("The home number must not be empty.");
        }

        internal ValidationResult Validate(PersonValidator user)
        {
            throw new NotImplementedException();
        }

        private bool BeAValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }

    }
}

