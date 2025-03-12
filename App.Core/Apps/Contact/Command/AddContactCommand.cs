using App.Core.Interface;
using AutoMapper;
using Domain.Model;
using Domain.Model.Reponses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Contact.Command
{
    public class AddContactCommand:IRequest<ApiResponse<object>>
    {
        public ContactDto contactDto { get; set; }
    }
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, ApiResponse<object>>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        public AddContactCommandHandler(IAppDbContext dbContext,IMapper mapper,IEmailService emailService,IEmailTemplateService emailTemplateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;

        }

        public async Task<ApiResponse<object>> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contactInfo=request.contactDto;
            var contactmapping= _mapper.Map<Domain.Entity.Contact>(contactInfo);
            contactmapping.SubmittedAt=DateTime.Now;
           
            _dbContext.Set<Domain.Entity.Contact>().Add(contactmapping);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
           var emailContent= _emailTemplateService.GenerateTemplateEmail(contactInfo.Name, contactInfo.Email, contactInfo.Subject, contactInfo.Message,contactmapping.SubmittedAt);
            await _emailService.SendEmailAsync("mayurramdham02@gmail.com", "Welcome to our platform  ", "Enquiry Message ", emailContent);


            var response = new ApiResponse<object>
            {
                Success = true,
                Data = contactmapping,
                StatusCode = 200,
                Message="Contact Added Successfully"
            };
            return response;

        }
    }
}
