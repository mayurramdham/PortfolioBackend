using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interface
{
    public interface IEmailTemplateService
    {
        string GenerateTemplateEmail(string name, string email, string subject, string message, DateTime submittedAt);
    }
}
