using LuxRide.Application.Features.Commands.Team.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Partner.DTOs
{
    public class PartnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string Path { get; set; }
    }
}
