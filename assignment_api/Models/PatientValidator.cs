using assignment_api.Enums;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace assignment_api.Models
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Please provide a name !");
            RuleFor(r => r.FileNo)
                .NotEmpty()
                .WithMessage("Please provide a file no !")
                .InclusiveBetween(1, 10)
                //.Must(Matches(@"^\d{1,10}$")
                .WithMessage("Max length for File No is 10 !");
            RuleFor(r => r.CitizenId)
                .NotEmpty()
                .WithMessage("Please provide a citizen id !");
            RuleFor(r => r.Birthdate)
                .NotEmpty()
                .WithMessage("Please provide a birth date !")
                .Must(BeAValidDate)
                .WithMessage("Invalid date/time");
            RuleFor(r => r.Gender).IsInEnum()
                .NotEmpty()
                .WithMessage("Please provide a gender !")
                 .WithMessage("The gender should be 0 (male) or 1 (female)");
            RuleFor(r => r.Natinality)
                .NotEmpty()
                .WithMessage("Please provide a natinality !");
            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .WithMessage("Please provide a phone number !")
                .Matches(@"^(?:00|\+)(90){1}[\d]{4,11}$")
                .WithMessage("Please check the phone number, should start with 0090");
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Please provide an email!")
                .EmailAddress()
                .WithMessage("A valid email is required");
        }
        private bool BeAValidDate(DateTime value)
        {
            //DateTime date;
            //return DateTime.TryParse(value, out date);
            return true;
        }
        private bool CheckFileNo(string arg)
        {
            //int _tempInt = 0;
            //int.TryParse
            var regex = new Regex(@"^(?:00|\+)(90){1}[\d]{4,11}$");
            return regex.IsMatch(arg);
        }
    }
}
