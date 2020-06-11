using Club_De_Sport.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_De_Sport.Validators.UnsubscribedValidators
{
    public class ActivitiesValidator : AbstractValidator<Activite>
    {
        public ActivitiesValidator()
        {
            RuleFor(a => a.Nom)
                .NotEqual("Activités").WithMessage("Veuillez choisir une activitée");
        }
    }
}
