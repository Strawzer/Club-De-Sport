using Club_De_Sport.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_De_Sport.Validators.AdminValidators
{
    public class AdherentsValidator : AbstractValidator<Adherent>
    {
        public AdherentsValidator()
        {
            RuleFor(a => a.Nom)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Must(BeAValidName).WithMessage("Veuillez Rentrer un Nom Valide.");
            RuleFor(a => a.Prenom)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Must(BeAValidName).WithMessage("Veuillez Rentrer un Prénom Valide.");
            RuleFor(a => a.Sexe)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual("Sexe").WithMessage("Veuillez Choisir votre {PropertyName}.");
            RuleFor(a => a.Cin)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.");
            RuleFor(a => a.Tel)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Length(10).WithMessage("Le Numéro de tel doit contenir 10 chiffres");
            RuleFor(a => a.TelUrgence)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Length(10).WithMessage("Le Numéro de tel doit contenir 10 chiffres");
            RuleFor(a => a.Adresse)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.");
            RuleFor(a => a.Ville)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Must(BeAValidName).WithMessage("Veuillez Rentrer un Nom de Ville Valide.");
            RuleFor(a => a.CNE)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Veuillez Remplire le champ {PropertyName}.")
                .Must(BeADigit).WithMessage("L'{PropertyName} doit etre un nombre");
        }
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
        protected bool BeADigit(string number)
        {
            return Int64.TryParse(number, out Int64 n);
        }
    }
}