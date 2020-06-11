using Club_De_Sport.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_De_Sport.Validators.AdminValidators
{
    public class SeanceValidator : AbstractValidator<Seance>
    {
        public SeanceValidator()
        {
            RuleFor(s => s.MinAdh.ToString())
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(BeADigit).WithMessage("{PropertyName} : Veuillez entrer un nombre valide");
            RuleFor(s => s.MaxAdh.ToString())
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(BeADigit).WithMessage("{PropertyName} : Veuillez entrer un nombre valide")
                .LessThan("11").WithMessage("{PropertyName} : Une séance ne peut pas dépasser 10 adhérants");
        }
        protected bool BeADigit(string number)
        {
            return Int64.TryParse(number, out Int64 n);
        }
    }
}
