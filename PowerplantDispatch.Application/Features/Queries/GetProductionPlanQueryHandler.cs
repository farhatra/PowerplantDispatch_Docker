using MediatR;
using PowerplantDispatch.Application.Contracts;
using PowerplantDispatch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Features.Queries
{
    public class GetProductionPlanQueryHandler : IRequestHandler<GetProductionPlanQuery, ProductionPlanDto>
    {
        private readonly IProductionPlanService _productionPlanService;

        public GetProductionPlanQueryHandler(IProductionPlanService productionPlanService)
        {
            _productionPlanService = productionPlanService;
        }

        public async Task<ProductionPlanDto> Handle(GetProductionPlanQuery request, CancellationToken cancellationToken)
        {
            // Assuming you have a method to get production plan details by Id
            var productionPlan = await _productionPlanService.GetProductionPlanByIdAsync(request.Id);
            return productionPlan;
        }
    }
}
