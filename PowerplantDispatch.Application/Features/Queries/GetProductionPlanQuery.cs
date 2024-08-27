using MediatR;
using PowerplantDispatch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Features.Queries
{
    public class GetProductionPlanQuery : IRequest<ProductionPlanDto>
    {
        public int Id { get; set; }
    }
}
