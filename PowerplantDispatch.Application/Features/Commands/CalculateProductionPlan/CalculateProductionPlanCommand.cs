using MediatR;
using PowerplantDispatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan
{
    public class CalculateProductionPlanCommand : IRequest<List<PowerOutput>>
    {
        public ProductionPlan ProductionPlan { get; set; }
    }
}
