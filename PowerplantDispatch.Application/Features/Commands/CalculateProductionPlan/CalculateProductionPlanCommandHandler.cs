using AutoMapper;
using MediatR;
using PowerplantDispatch.Application.Contracts;
using PowerplantDispatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan
{
    public class CalculateProductionPlanCommandHandler : IRequestHandler<CalculateProductionPlanCommand, List<PowerOutput>>
    {
        private readonly IProductionPlanService _productionPlanService;
        private readonly IMapper _mapper;

        public CalculateProductionPlanCommandHandler(IProductionPlanService productionPlanService, IMapper mapper)
        {
            _productionPlanService = productionPlanService;
            _mapper = mapper;
        }

        public async Task<List<PowerOutput>> Handle(CalculateProductionPlanCommand request, CancellationToken cancellationToken)
        {
            return await _productionPlanService.CalculateProductionPlanAsync(request.ProductionPlan);
        }
    }
}
