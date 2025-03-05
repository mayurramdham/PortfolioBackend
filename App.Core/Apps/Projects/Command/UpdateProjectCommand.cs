using App.Core.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Projects.Command
{
    public class UpdateProjectCommand : IRequest<ProjectDto>
    {
        public ProjectForUpdateDto ProjectDto { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ProjectDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectId = request.ProjectDto.Id;
            var project = await _context.Set<Project>().FindAsync(projectId);
            if (project == null)
                throw new KeyNotFoundException("Project not found");

            // Map the updated DTO fields to the entity
            _mapper.Map(request.ProjectDto, project);
            await _context.SaveChangesAsync(cancellationToken);

            // Return the updated project as a DTO
            return _mapper.Map<ProjectDto>(project);
        }
    }
}
