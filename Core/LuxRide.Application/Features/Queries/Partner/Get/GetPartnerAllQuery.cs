using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Partner.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Partner.Get
{
	public class GetPartnerAllQuery:IRequest<List<PartnerDto>>
	{ 
	}
}
