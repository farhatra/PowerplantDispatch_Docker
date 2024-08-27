using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerplantDispatch.Application.DTOs;
using PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan;
using PowerplantDispatch.Domain.Entities;

namespace PowerplantDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductionPlanController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Calculate the production plan based on the provided data..
        /// </summary>
        /// <param name="productionPlanDto">The data needed to calculate the production plan.</param>
        /// <returns>List of power outputs for each power plant.</returns>
        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateProductionPlan([FromBody] ProductionPlanDto productionPlanDto)
        {
            // Map ProductionPlanDto to ProductionPlan domain entity
            var productionPlan = _mapper.Map<ProductionPlan>(productionPlanDto);

            // Create the command with the mapped domain entity
            var command = new CalculateProductionPlanCommand { ProductionPlan = productionPlan };

            // Send the command via MediatR
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
