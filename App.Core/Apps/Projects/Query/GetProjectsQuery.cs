using App.Core.Interface;
using AutoMapper;
using Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Projects.Query
{
    public class GetProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {
    }
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Set<Domain.Entity.Project>().ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
    }
}
