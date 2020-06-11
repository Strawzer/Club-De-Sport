using Club_De_Sport.Models;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_De_Sport.Validators
{
    public class IdentificationValidator : AbstractValidator<User>
    {
        public IdentificationValidator()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName} du client.")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Veuillez Entrer Une Adresse Email Valide.");
            RuleFor(u => u.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez saisir un mot de passe.")
                .MinimumLength(8).WithMessage("Le mot de passe doit contenire au moins 8 caractères");
        }
    }
}