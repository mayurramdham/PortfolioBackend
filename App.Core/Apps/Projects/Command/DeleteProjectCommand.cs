using App.Core.Interface;
using Domain.Entity;
using Domain.Model.Reponses; // Adjust if necessary (e.g., "Responses")
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Projects.Command
{
    public class DeleteProjectCommand : IRequest<ApiResponse<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ApiResponse<bool>>
    {
        private readonly IAppDbContext _context;

        public DeleteProjectCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Set<Project>().FindAsync(new object[] { request.Id }, cancellationToken);
            if (project == null)
            {
                return new ApiResponse<bool>
                {
                    StatusCode = 404,
                    Message = "Project not found.",
                    Data = false,
                    Success = false
                };
            }

            _context.Set<Project>().Remove(project);
            await _context.SaveChangesAsync(cancellationToken);

            return new ApiResponse<bool>
            {
                StatusCode = 200,
                Message = "Project deleted successfully.",
                Data = true,
                Success = true
            };
        }
    }
}
