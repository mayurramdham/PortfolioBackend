using AutoMapper;
using Domain.Entity;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Projects
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectForCreationDto, Project>();
            CreateMap<ProjectForUpdateDto, Project>()
       .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // Avoid overwriting CreatedAt
            // Mapping for UserProfile
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileForUpdateDto, UserProfile>();

            // Mapping for Skills
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillForCreationDto, Skill>();

            // Mapping for Experience
            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceForCreationDto, Experience>();

            // Mapping for Education
            CreateMap<Education, EducationDto>();
            CreateMap<EducationForCreationDto, Education>();

            // Mapping for Testimonials
            CreateMap<Testimonial, TestimonialDto>();
            CreateMap<TestimonialForCreationDto, Testimonial>();

            // Mapping for Contacts
            //CreateMap<Domain.Entity.Contact, ContactDto>();
            CreateMap<ContactDto, Domain.Entity.Contact>();

            // Mapping for User (Admin) – note that password is not mapped back
            CreateMap<User, UserDto>();
        }
    }
}
