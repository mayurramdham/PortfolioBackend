using App.Core.Apps.Projects.Command;
using App.Core.Apps.Projects.Query;
using Domain.Model.Reponses;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/projects
        [HttpGet("getAllProject")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProjectDto>>>> GetProjects()
        {
            var query = new GetProjectsQuery();
            var projects = await _mediator.Send(query);

            var response = new ApiResponse<IEnumerable<ProjectDto>>
            {
                StatusCode = 200,
                Message = "Projects retrieved successfully.",
                Data = projects,
                Success = true
            };

            return Ok(response);
        }

        // POST: api/projects
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> CreateProject([FromBody] ProjectForCreationDto projectDto)
        {
            var command = new CreateProjectCommand { ProjectDto = projectDto };
            var createdProject = await _mediator.Send(command);

            var response = new ApiResponse<ProjectDto>
            {
                StatusCode = 201,
                Message = "Project created successfully.",
                Data = createdProject,
                Success = true
            };

            return CreatedAtAction(nameof(GetProjects), new { id = createdProject.Id }, response);
        }

        // PUT: api/projects/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> UpdateProject(int id, [FromBody] ProjectForUpdateDto projectDto)
        {
            if (id != projectDto.Id)
            {
                return BadRequest(new ApiResponse<ProjectDto>
                {
                    StatusCode = 400,
                    Message = "Project ID mismatch.",
                    Data = null,
                    Success = false
                });
            }

            var command = new UpdateProjectCommand { ProjectDto = projectDto };
            var updatedProject = await _mediator.Send(command);

            var response = new ApiResponse<ProjectDto>
            {
                StatusCode = 200,
                Message = "Project updated successfully.",
                Data = updatedProject,
                Success = true
            };

            return Ok(response);
        }
    

    // DELETE: api/projects/{id}
    [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteProject(int id)
        {
            await _mediator.Send(new DeleteProjectCommand { Id = id });

            var response = new ApiResponse<object>
            {
                StatusCode = 204,
                Message = "Project deleted successfully.",
                Data = null,
                Success = true
            };

            return Ok(response);
        }
    }
}
