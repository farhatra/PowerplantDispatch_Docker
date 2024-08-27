using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan
{
    public class CalculateProductionPlanCommandValidator : AbstractValidator<CalculateProductionPlanCommand>
    {
        public CalculateProductionPlanCommandValidator()
        {
            RuleFor(x => x.ProductionPlan).NotNull().WithMessage("Production Plan cannot be null.");
            RuleFor(x => x.ProductionPlan.Load).GreaterThan(0).WithMessage("Load must be greater than zero.");
            RuleFor(x => x.ProductionPlan.Fuels).NotNull().WithMessage("Fuels cannot be null.");
            RuleFor(x => x.ProductionPlan.PowerPlants).NotEmpty().WithMessage("Power plants cannot be empty.");
        }
    }
}
