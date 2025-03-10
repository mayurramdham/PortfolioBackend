using App.Core.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Projects.Command
{
    public class CreateProjectCommand : IRequest<ProjectDto>
    {
        public ProjectForCreationDto ProjectDto { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            // Map the creation DTO to the Project entity
            var project = _mapper.Map<Project>(request.ProjectDto);
            project.CreatedAt = System.DateTime.UtcNow;

            _context.Set<Domain.Entity.Project>().Add(project);
            await _context.SaveChangesAsync(cancellationToken);

            // Map back to the response DTO
            return _mapper.Map<ProjectDto>(project);
        }
    }
}
